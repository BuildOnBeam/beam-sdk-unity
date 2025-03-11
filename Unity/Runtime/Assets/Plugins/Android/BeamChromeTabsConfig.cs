using System;
using UnityEngine;

namespace Beam.ChromeTabs
{
    public class BeamChromeTabsConfig
    {
        /// <summary>
        /// Custom Toolbar color. Defaults to #131313
        /// </summary>
        public string ColorString { get; set; } = "#131313";
        
        public AndroidJavaObject ToAndroidJavaClass()
        {
            AndroidJavaObject javaConfig = new AndroidJavaObject("com.onbeam.beamchrometabs.utils.BeamChromeTabsConfig");
            javaConfig.Set("colorString", ColorString);
            return javaConfig;
        }
    }
}