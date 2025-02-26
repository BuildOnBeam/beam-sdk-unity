#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;
using UnityEditor.Android;
using UnityEngine;

namespace Beam
{
    public class AndroidProcessor : IPostGenerateGradleAndroidProject
    {
        public int callbackOrder { get { return 0; } }
        public void OnPostGenerateGradleAndroidProject(string path)
        {
            AddUseAndroidX(path);
        }

        private void AddUseAndroidX(string path)
        {
            var parentDir = Directory.GetParent(path).FullName;
            var gradlePath = parentDir + "/gradle.properties";
            
            Debug.Log($"Looking for gradle.properties under: {gradlePath}");

            if (!File.Exists(gradlePath))
                throw new Exception("gradle.properties does not exist");

            var text = File.ReadAllText(gradlePath);

            text += "\nandroid.useAndroidX=true\nandroid.enableJetifier=true";

            File.WriteAllText(gradlePath, text);
        }
    }
}

#endif
