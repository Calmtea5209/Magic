using UnityEngine;
using System.IO;

public class ScreenshotManager : MonoBehaviour
{
    public Camera targetCamera;
    public string filenamePrefix = "Screenshot";
    public string savePath = "/Screenshots/";
    public KeyCode screenshotKey = KeyCode.T;

    void Update()
    {
        if (Input.GetKeyDown(screenshotKey))
        {
            string filename = filenamePrefix + "_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            string filePath = Application.dataPath + savePath + filename;

            RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
            targetCamera.targetTexture = renderTexture;
            targetCamera.Render();

            RenderTexture.active = renderTexture;
            Texture2D screenshotTexture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
            screenshotTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            screenshotTexture.Apply();
            byte[] screenshotBytes = screenshotTexture.EncodeToPNG();
            File.WriteAllBytes(filePath, screenshotBytes);


            Destroy(screenshotTexture);
            RenderTexture.active = null;
            targetCamera.targetTexture = null;
            RenderTexture.Destroy(renderTexture);

            Debug.Log("Screenshot saved to " + filePath);
        }
    }
}
