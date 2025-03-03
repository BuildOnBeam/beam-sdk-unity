package com.onbeam.beamchrometabs.activities;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;

import androidx.annotation.Nullable;

// Activity which handles deeplinks
public class CallbackActivity extends Activity {
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Log.d("CallbackActivity", "GOT INTO CALLBACK ACTIVITY.");
        Intent intent = new Intent(this, ChromeTabActivity.class);
        if (getIntent() != null) {
            intent.setData(getIntent().getData());
        }
        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_SINGLE_TOP);
        intent.putExtra("isComingFromCallback", true);
        startActivity(intent);
        finish();
    }
}

