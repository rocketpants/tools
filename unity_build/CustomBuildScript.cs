using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
using System.Collections;
using System.Collections.Generic;

namespace RocketPants {
    class BuildScript {
        static string APP_NAME = "GameName";

        private static BuildPlayerOptions baseOptions {
            get {
                var options = new BuildPlayerOptions();
                options.scenes = FindEnabledEditorScenes();
                options.options = BuildOptions.None;
                return options;
            }
        }

        public static void PerformCIBuild(string buildPath) {
            BuildPlayerOptions buildPlayerOptions = baseOptions;
            buildPlayerOptions.locationPathName = buildPath;
            BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        }

        public static void PerformCIBuildWindows32() {
            PerformCIBuild("build/Windows32");
        }

        public static void PerformCIBuildWindows64() {
            PerformCIBuild("build/Windows64");
        }

        public static void PerformCIBuildMac() {
            PerformCIBuild("build/Mac");
        }

        public static void PerformCIBuildLinux() {
            PerformCIBuild("build/Linux");
        }

        public static void PerformCIBuildAndroid() {
            PerformCIBuild(string.Format("build/Android/{0}.apk", APP_NAME));
        }

        public static void PerformCIBuildIos() {
            PerformCIBuild("build/iOS");
        }

        private static string[] FindEnabledEditorScenes() {
            List<string> EditorScenes = new List<string>();
            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
                if (scene.enabled) {
                    EditorScenes.Add(scene.path);
                }
            }
            return EditorScenes.ToArray();
        }
    }
}
