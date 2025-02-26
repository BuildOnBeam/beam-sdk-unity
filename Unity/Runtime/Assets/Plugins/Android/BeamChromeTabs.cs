using UnityEngine;

namespace Beam.ChromeTabs
{
    public class BeamChromeTabs
    {
        public const string DefaultUnityMainActivity = "com.unity3d.player.UnityPlayer";

        public static void OpenCustomTab(string urlToLaunch, string colorCode, string secColorCode, bool showTitle = false,
            bool showUrlBar = false, string mainActivity = DefaultUnityMainActivity)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                using (var javaUnityPlayer = new AndroidJavaClass(mainActivity ?? DefaultUnityMainActivity))
                {
                    using (var mContext = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                    {
                        using (AndroidJavaClass jc = new AndroidJavaClass("com.onbeam.beamchrometabs.CustomTabPlugin"))
                        {
                            var mAuthManager = jc.CallStatic<AndroidJavaObject>("getInstance");
                            mAuthManager.Call<AndroidJavaObject>("setActivity", mContext);
                            mAuthManager.Call<AndroidJavaObject>("setUrl", urlToLaunch);
                            mAuthManager.Call<AndroidJavaObject>("setColorString", colorCode);
                            mAuthManager.Call<AndroidJavaObject>("setSecondaryColorString", secColorCode);
                            mAuthManager.Call<AndroidJavaObject>("ToggleShowTitle", showTitle);
                            mAuthManager.Call<AndroidJavaObject>("ToggleUrlBarHiding", showUrlBar);
                            mAuthManager.Call("openCustomTab");
                        }
                    }
                }
            }
        }
    }
}