package com.onbeam.beamchrometabs.utils;


import android.app.Activity;
import android.content.ActivityNotFoundException;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;

import androidx.annotation.NonNull;
import androidx.browser.customtabs.CustomTabsCallback;
import androidx.browser.customtabs.CustomTabsClient;
import androidx.browser.customtabs.CustomTabsIntent;
import androidx.browser.customtabs.CustomTabsServiceConnection;
import androidx.browser.customtabs.CustomTabsSession;

import java.lang.ref.WeakReference;
import java.util.List;
import java.util.concurrent.atomic.AtomicReference;

/**
 * This is a helper class to manage the connection to the Custom Tabs Service.
 */
public class CustomTabsConnector extends CustomTabsServiceConnection {
    private final WeakReference<Activity> context;
    private AtomicReference<CustomTabsSession> session;
    private CustomTabsCallback customTabsCallback;
    private String packageName;
    private boolean isServiceBound = false;

    public CustomTabsConnector(@NonNull Activity context, CustomTabsCallback callback) {
        this.context = new WeakReference<>(context);
        this.session = new AtomicReference<>();
        this.customTabsCallback = callback;
        packageName = CustomTabsPackagePicker.getPackageNameToUse(context);
    }

    @Override
    public void onCustomTabsServiceConnected(@NonNull ComponentName name, @NonNull CustomTabsClient client) {
        client.warmup(0L);
        CustomTabsSession customTabsSession = client.newSession(customTabsCallback);
        session.set(customTabsSession);
    }

    @Override
    public void onServiceDisconnected(ComponentName name) {
        session.set(null);
    }

    /**
     * Opens the URL on a Custom Tab if possible. Otherwise falls back to opening it using any browser.
     *
     * @param customTabsIntent a CustomTabsIntent to be used if Custom Tabs is available.
     * @param uri the Uri to be opened.
     */
    public void openCustomTab(CustomTabsIntent customTabsIntent, Uri uri) {
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
            try {
                customTabsIntent.intent.setPackage(packageName);
                customTabsIntent.launchUrl(context, uri);
            } catch (ActivityNotFoundException ex) {
                Log.e("CustomTabsConnector", "Encountered an error when trying to open Custom Tabs", ex);
                // Failed to launch Custom Tab browser, so launch in browser
                context.startActivity(new Intent(Intent.ACTION_VIEW, uri));
            }
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
}
