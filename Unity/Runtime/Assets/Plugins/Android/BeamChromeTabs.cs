using UnityEngine;

namespace Beam.ChromeTabs
{
    public class BeamChromeTabs
    {
        public static void OpenCustomTab(string urlToLaunch, BeamChromeTabsConfig config, BeamChromeTabsCallback callback)
        {
            #if UNITY_ANDROID //&& !UNITY_EDITOR
            if (Application.platform == RuntimePlatform.Android)
            {
                using (var javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
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