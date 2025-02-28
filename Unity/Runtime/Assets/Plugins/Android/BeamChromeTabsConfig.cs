using System;
using UnityEngine;

namespace Beam.ChromeTabs
{
    public class BeamChromeTabsConfig
    {
        public string ColorString { get; set; } = "";
        public string SecondaryColorString { get; set; } = "";
        public bool ShowTitle { get; set; } = false;
        public bool UrlBarHiding { get; set; } = false;
        
        public AndroidJavaObject ToAndroidJavaClass()
        {
            AndroidJavaObject javaConfig = new AndroidJavaObject("com.onbeam.beamchrometabs.utils.BeamChromeTabsConfig");
            javaConfig.Set("colorString", ColorString);
            javaConfig.Set("secondaryColorString", SecondaryColorString);
            javaConfig.Set("showTitle", ShowTitle);
            javaConfig.Set("urlBarHiding", UrlBarHiding);
            return javaConfig;
        }
    }
}