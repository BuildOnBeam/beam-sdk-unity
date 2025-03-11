package com.onbeam.beamchrometabs.activities;

import android.app.Activity;
import android.content.ActivityNotFoundException;
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
import androidx.browser.customtabs.CustomTabsIntent;

import com.onbeam.beamchrometabs.utils.BeamChromeTabsCallback;
import com.onbeam.beamchrometabs.utils.BeamChromeTabsConfig;
import com.onbeam.beamchrometabs.utils.CustomTabsConnector;
import com.onbeam.beamchrometabs.R;

import java.lang.ref.WeakReference;

public class ChromeTabActivity extends Activity {

    private static final int TOOLBAR_ITEM_ID = 1;

    private String urlToLaunch = "";
    private String colorString = "";
    private boolean isComingFromCallback = false;
    private boolean isCustomTabOpened = false;

    private CustomTabsConnector customTabsConnector;

    private static BeamChromeTabsCallback callbackInstance;

    public static void startActivity(Context context, String url, BeamChromeTabsConfig config, BeamChromeTabsCallback callback) {
        callbackInstance = callback;

        Intent intent = new Intent(context, ChromeTabActivity.class);
        intent.putExtra("urlToLaunch", url);
        intent.putExtra("colorString", config.colorString);

        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);

        context.startActivity(intent);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        if (savedInstanceState != null) {
            isCustomTabOpened = savedInstanceState.getBoolean("isCustomTabOpened", false);
        }

        customTabsConnector = new CustomTabsConnector(this, new CustomTabsCallback());
    }

    @Override
    protected void onSaveInstanceState(@NonNull Bundle outState) {
        super.onSaveInstanceState(outState);
        outState.putString("urlToLaunch", urlToLaunch);
        outState.putString("colorString", colorString);
        outState.putBoolean("isComingFromCallback", isComingFromCallback);
        outState.putBoolean("isCustomTabOpened", isCustomTabOpened);
    }

    @Override
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        setIntent(intent);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (resultCode == RESULT_CANCELED) {
            callbackInstance.onCancel();
        } else {
            callbackInstance.onFinished();
        }
        finish();
    }

    @Override
    protected void onResume() {
        super.onResume();
        Intent callingIntent = getIntent();

        handleIntent(callingIntent);

        Log.d("ChromeTabActivity", String.format("onResume. isComingFromCallback: %b isCustomTabOpened: %b callbackInstance != null: %b callingIntent.getExtras() == null: %b", isComingFromCallback, isCustomTabOpened, callbackInstance != null, callingIntent.getExtras() == null));

        if (isCustomTabOpened && getIntent().getData() == null && callbackInstance != null) {
            // User cancelled flow
            callbackInstance.onCancel();
        }

        if (!isCustomTabOpened && callingIntent.getExtras() == null) {
            // This activity was launched in an unexpected way
            finish();
            return;
        } else if (!isCustomTabOpened) {
            // Haven't launched custom tabs
            isCustomTabOpened = true;
            openCustomTab();
            return;
        }

        if (callbackInstance != null && callingIntent != null && callingIntent.getData() != null) {
            callbackInstance.onFinished();
        }
        finish();
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        Log.d("ChromeTabActivity", String.format("onDestroy. isComingFromCallback: %b", isComingFromCallback));
    }

    void handleIntent(Intent intent) {
        if (intent == null || intent.getExtras() == null) return;

        if (intent.getExtras().containsKey("urlToLaunch")) {
            urlToLaunch = intent.getExtras().getString("urlToLaunch");
        }
        if (intent.getExtras().containsKey("colorString")) {
            colorString = intent.getExtras().getString("colorString");
        }
        if (intent.getExtras().containsKey("isComingFromCallback")) {
            isComingFromCallback = intent.getExtras().getBoolean("isComingFromCallback");
        } else {
            isComingFromCallback = false;
        }
    }

    @Override
    protected void onStart() {
        super.onStart();
        Log.d("ChromeTabActivity", String.format("onStart. isComingFromCallback: %b", isComingFromCallback));
        customTabsConnector.bindCustomTabsService();
    }

    @Override
    protected void onStop() {
        super.onStop();
        Log.d("ChromeTabActivity", String.format("onStop. isComingFromCallback: %b", isComingFromCallback));
        customTabsConnector.unbindCustomTabsService();
    }

    private void openCustomTab() {
        Log.d("ChromeTabActivity", String.format("openCustomTab with session builder. urlToLaunch: %s", urlToLaunch));

        customTabsConnector.openCustomTab(Uri.parse(urlToLaunch), this.colorString);
        isCustomTabOpened = true;
    }
}