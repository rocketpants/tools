using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Screenshot))]
public class ScreenshotEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        Screenshot subject = (Screenshot)target;
        if (GUILayout.Button("Take screenshot")) {
            subject.TakeScreenshot();
        }
    }
}
