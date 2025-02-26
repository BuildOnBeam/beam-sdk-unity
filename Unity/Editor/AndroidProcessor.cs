#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor.Android;
using UnityEngine;

namespace Beam.Editor.Processors
{
    public class AndroidProcessor : IPostGenerateGradleAndroidProject
    {
        public int callbackOrder { get { return 0; } }
        public void OnPostGenerateGradleAndroidProject(string path)
        {
            Debug.Log("AndroidProcessor.OnPostGenerateGradleAndroidProject at path " + path);

            var parentDir = Directory.GetParent(path).FullName;
            var gradlePath = parentDir + "/gradle.properties";

            if (!File.Exists(gradlePath))
                throw new Exception("gradle.properties does not exist");

            var text = File.ReadAllText(gradlePath);

            text += "\nandroid.useAndroidX=true\nandroid.enableJetifier=true";

            File.WriteAllText(gradlePath, text);
        }
    }
}

#endif
