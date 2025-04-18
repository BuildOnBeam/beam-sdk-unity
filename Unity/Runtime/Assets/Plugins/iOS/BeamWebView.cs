using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Plugins.iOS
{
    public class BeamWebView : MonoBehaviour
    {
#if UNITY_IOS && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern IntPtr _CreateWebView();

        [DllImport("__Internal")]
        private static extern void _LoadUrl(IntPtr pointer, string url);

        [DllImport("__Internal")]
        private static extern void _DismissWebView(IntPtr pointer);

        [DllImport("__Internal")]
        private static extern void _DestroyWebView(IntPtr pointer);
#endif

        private IntPtr nativeWebView;

        public event Action OnWebViewClosed;
        public event Action<string> OnWebViewError;
        public event Action<string> OnWebViewSuccess;

        public BeamWebView()
        {
#if UNITY_IOS && !UNITY_EDITOR
            nativeWebView = _CreateWebView();
#endif
            name = "BeamWebView";
        }

        public void LoadUrl(string url)
        {
#if UNITY_IOS && !UNITY_EDITOR
            if (nativeWebView != IntPtr.Zero)
            {
                _LoadUrl(nativeWebView, url);
            }
#endif
        }

        public void Dismiss()
        {
#if UNITY_IOS && !UNITY_EDITOR
            if (nativeWebView != IntPtr.Zero)
            {
                _DismissWebView(nativeWebView);
                OnWebViewClosed?.Invoke();
            }
#endif
        }

        public void Dispose()
        {
#if UNITY_IOS && !UNITY_EDITOR
            if (nativeWebView != IntPtr.Zero)
            {
                _DestroyWebView(nativeWebView);
                nativeWebView = IntPtr.Zero;
            }
#endif
        }

        private void HandleError(string errorDetails)
        {
            var parts = errorDetails.Split('|');
            if (parts.Length == 2)
            {
                OnWebViewError?.Invoke($"URL: {parts[0]}, Error: {parts[1]}");
            }
            else
            {
                OnWebViewError?.Invoke(errorDetails);
            }
        }
        private void HandleSuccess(string url) => OnWebViewSuccess?.Invoke(url);
    }
}