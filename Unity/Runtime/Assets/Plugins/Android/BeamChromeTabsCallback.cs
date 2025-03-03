using System;
using UnityEngine;

namespace Beam.ChromeTabs
{
    public class BeamChromeTabsCallback : AndroidJavaProxy
    {
        private readonly Action onCancelCallback;
        private readonly Action onFinishedCallback;
        public BeamChromeTabsCallback(Action onCancel, Action onFinished) : base(
            "com.onbeam.beamchrometabs.utils.BeamChromeTabsCallback")
        {
            this.onCancelCallback = onCancel;
            this.onFinishedCallback = onFinished;
        }

        public void onCancel()
        {
            onCancelCallback.Invoke();
        }

        public void onFinished()
        {
            onFinishedCallback.Invoke();
        }
    }
}