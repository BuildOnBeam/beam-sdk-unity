package com.onbeam.beamchrometabs.utils;


import android.app.Activity;
import android.content.ActivityNotFoundException;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.Insets;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.util.DisplayMetrics;
import android.util.Log;
import android.view.WindowInsets;
import android.view.WindowMetrics;

import androidx.annotation.NonNull;
import androidx.browser.customtabs.CustomTabColorSchemeParams;
import androidx.browser.customtabs.CustomTabsCallback;
import androidx.browser.customtabs.CustomTabsClient;
import androidx.browser.customtabs.CustomTabsIntent;
import androidx.browser.customtabs.CustomTabsServiceConnection;
import androidx.browser.customtabs.CustomTabsSession;

import com.onbeam.beamchrometabs.R;

import java.lang.ref.WeakReference;
import java.util.List;
import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.atomic.AtomicReference;

/**
 * This is a helper class to manage the connection to the Custom Tabs Service.
 */
public class CustomTabsConnector extends CustomTabsServiceConnection {
    private final WeakReference<Activity> context;
    private AtomicReference<CustomTabsSession> session;
    private final CountDownLatch sessionLatch;
    private CustomTabsCallback customTabsCallback;
    private String packageName;
    private boolean isServiceBound = false;

    public CustomTabsConnector(@NonNull Activity context, CustomTabsCallback callback) {
        this.context = new WeakReference<>(context);
        this.session = new AtomicReference<>();
        this.customTabsCallback = callback;
        this.sessionLatch = new CountDownLatch(1);
        packageName = CustomTabsPackagePicker.getPackageNameToUse(context);
    }

    @Override
    public void onCustomTabsServiceConnected(@NonNull ComponentName name, @NonNull CustomTabsClient client) {
        client.warmup(0L);
        CustomTabsSession customTabsSession = client.newSession(customTabsCallback);
        session.set(customTabsSession);
        Log.d("CustomTabsConnector", "onCustomTabsServiceConnected");
    }

    @Override
    public void onServiceDisconnected(ComponentName name) {
        session.set(null);
    }

    /**
     * Opens the URL on a Custom Tab if possible. Otherwise falls back to opening it using any browser.
     */
    public void openCustomTab(Uri uri, String colorString) {
        final Activity context = this.context.get();
        if (context == null) {
            // Custom tabs context is no longer valid
            return;
        }

        //If we cant find a package name, it means theres no browser that supports
        //Chrome Custom Tabs installed. Fall back to any browser
        if (packageName == null) {
            context.startActivity(new Intent(Intent.ACTION_VIEW, uri));
        } else {
            new Thread(() -> {
                try {
                    // we need to wait for Custom Tab session to be started
                    boolean ignored = sessionLatch.await(1, TimeUnit.SECONDS);
                } catch (InterruptedException ignored) {
                }
                try {
                    // if session is not started by the time we start the activity
                    // most of these settings won't work
                    // see https://developer.chrome.com/docs/android/custom-tabs/guide-partial-custom-tabs/
                    // we set session in onCustomTabsServiceConnected()
                    CustomTabsIntent.Builder intentBuilder = new CustomTabsIntent.Builder(this.session.get());
                    CustomTabColorSchemeParams.Builder defaultBuilder = new CustomTabColorSchemeParams.Builder();
                    if (!colorString.isEmpty())
                        defaultBuilder.setToolbarColor(Color.parseColor(colorString));
                    CustomTabColorSchemeParams defaultColors = defaultBuilder.build();

                    intentBuilder.setDefaultColorSchemeParams(defaultColors);

                    intentBuilder.setShareState(CustomTabsIntent.SHARE_STATE_OFF);
                    intentBuilder.setInitialActivityHeightPx(getCustomTabsHeight(context), CustomTabsIntent.ACTIVITY_HEIGHT_FIXED);

                    CustomTabsIntent customTabsIntent = intentBuilder.build();
                    customTabsIntent.launchUrl(context, uri);
                } catch (ActivityNotFoundException ex) {
                    Log.e("CustomTabsConnector", "Encountered an error when trying to open Custom Tabs", ex);
                    // Failed to launch Custom Tab browser, so launch in browser
                    context.startActivity(new Intent(Intent.ACTION_VIEW, uri));
                }

            }).start();
        }
    }

    /**
     * Binds the Activity to the Custom Tabs Service.
     */
    public void bindCustomTabsService() {
        Context context = this.context.get();
        if (context != null && packageName != null) {
            CustomTabsClient.bindCustomTabsService(context, packageName, this);
            isServiceBound = true;
        }
    }

    /**
     * Unbinds the Activity from the Custom Tabs Service.
     */
    public void unbindCustomTabsService() {
        Context context = this.context.get();
        if (isServiceBound && context != null) {
            context.unbindService(this);
            isServiceBound = false;
        }
    }

    private int getCustomTabsHeight(Activity context) {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
            WindowMetrics windowMetrics = context.getWindowManager().getCurrentWindowMetrics();
            Insets insets = windowMetrics.getWindowInsets()
                    .getInsetsIgnoringVisibility(WindowInsets.Type.systemBars());
            return windowMetrics.getBounds().height() - insets.top - insets.bottom;
        } else {
            DisplayMetrics displayMetrics = new DisplayMetrics();
            context.getWindowManager().getDefaultDisplay().getMetrics(displayMetrics);
            return displayMetrics.heightPixels;
        }
    }
}
