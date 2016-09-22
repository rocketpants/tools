using UnityEngine;
using System.Collections;

public class Screenshot : MonoBehaviour {
    public int width = 1920;
    public int height = 1080;
    public string path = Application.dataPath;
    public string fileName = "screenshot";

    private bool takeScreenshot = false;

    public string ScreenshotPath() {
        return string.Format("{0}/{1}.png", path, fileName);
    }

    public void TakeScreenshot() {
        takeScreenshot = true;
        SaveScreenshot();
    }

    void LateUpdate() {
        takeScreenshot |= Input.GetKeyDown("k");
        SaveScreenshot();
    }

    private void SaveScreenshot() {
        bool pathExists = System.IO.Directory.Exists(path);

        if (pathExists && takeScreenshot) {
            RenderTexture rt = new RenderTexture(width, height, 24);
            GetComponent<Camera>().targetTexture = rt;
            Texture2D screenShot = new Texture2D(width, height, TextureFormat.RGB24, false);
            GetComponent<Camera>().Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            GetComponent<Camera>().targetTexture = null;
            RenderTexture.active = null; // JC: added to avoid errors
            DestroyImmediate(rt);
            byte[] bytes = screenShot.EncodeToPNG();
            string filePath = ScreenshotPath();
            System.IO.File.WriteAllBytes(filePath, bytes);
            Debug.Log(string.Format("Screenshot saved to {0}", filePath));
            takeScreenshot = false;
        } else if (!pathExists) {
            Debug.Log(string.Format("Path not found: {0}", path));
        }
    }
}
