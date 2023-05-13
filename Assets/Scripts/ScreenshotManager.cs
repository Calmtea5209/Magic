using UnityEngine;
using System.IO;

public class ScreenshotManager : MonoBehaviour
{

    public string filenamePrefix = "Screenshot";


    public string savePath = "/Screenshots/";


    public KeyCode screenshotKey = KeyCode.T;


    void Update()
    {

        if (Input.GetKeyDown(screenshotKey))
        {
            
            string filename = filenamePrefix + "_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";

            
            string filePath = Application.dataPath + savePath + filename;

            
            ScreenCapture.CaptureScreenshot(filePath);


            Debug.Log("Screenshot saved to " + filePath);
        }
    }
}
