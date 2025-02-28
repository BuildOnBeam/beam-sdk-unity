using UnityEngine;

namespace Beam.ChromeTabs
{
    public class BeamChromeTabs
    {
        public const string DefaultUnityMainActivity = "com.unity3d.player.UnityPlayer";

        public static void OpenCustomTab(string urlToLaunch, BeamChromeTabsConfig config, BeamChromeTabsCallback callback, string mainActivity = DefaultUnityMainActivity)
        {
            #if UNITY_ANDROID && !UNITY_EDITOR
            if (Application.platform == RuntimePlatform.Android)
            {
                using (var javaUnityPlayer = new AndroidJavaClass(mainActivity ?? DefaultUnityMainActivity))
                {
                    using (var mContext = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                    {
                        using (AndroidJavaClass jc = new AndroidJavaClass("com.onbeam.beamchrometabs.activities.ChromeTabActivity"))
                        {
                            jc.CallStatic("startActivity", mContext, urlToLaunch, config.ToAndroidJavaClass(), callback);
                        }
                    }
                }
            }
            #endif
        }
    }
}