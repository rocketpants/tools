using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

class CustomBuildScript {
    static string[] SCENES = FindEnabledEditorScenes();

    static string APP_NAME = "GameName";
    static string TARGET_DIR = "Build";

    private static BuildPlayerOptions baseOptions {
        get {
            var options = new BuildPlayerOptions();
            options.scenes = SCENES;
            options.options = BuildOptions.None;
            return options;
        }
    }

    [MenuItem ("Custom/CI/Build Mac OS X")]
    static void PerformMacOSXBuild() {
        BuildPlayerOptions buildPlayerOptions = baseOptions;
        buildPlayerOptions.locationPathName = GetOutputPath("OSX", ".app");
        buildPlayerOptions.target = BuildTarget.StandaloneOSX;

        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }

    [MenuItem ("Custom/CI/Build Windows")]
    static void PerformWindowsBuild() {
        BuildPlayerOptions buildPlayerOptions = baseOptions;
        buildPlayerOptions.locationPathName = GetOutputPath("Win64", ".exe");
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;

        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }

    [MenuItem ("Custom/CI/Build Android")]
    static void PerformAndroidBuild() {
        BuildPlayerOptions buildPlayerOptions = baseOptions;
        buildPlayerOptions.locationPathName = GetOutputPath("Android", ".apk");
        buildPlayerOptions.target = BuildTarget.Android;

        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }

    [MenuItem ("Custom/CI/Build iOS")]
    static void PerformiOSBuild() {
        BuildPlayerOptions buildPlayerOptions = baseOptions;
        buildPlayerOptions.locationPathName = GetOutputPath("iOS", "");
        buildPlayerOptions.target = BuildTarget.iOS;

        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }

    private static string GetOutputPath(string suffix, string extension) {
        string[] args = System.Environment.GetCommandLineArgs();

        if (args.Length > 0) {
            TARGET_DIR = args[args.Length - 1];
        }

	    return string.Format("{0}/{1}-{2}{3}", TARGET_DIR, APP_NAME, suffix, extension);
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
