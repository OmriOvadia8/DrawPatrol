using UnityEngine;

public class SaveDrawing : MonoBehaviour
{
    private static SaveDrawing instance;
    private Camera myCam;
    private bool takeScreenshotNextFrame;
    private int screenshotCounter = 1;

    private void Awake()
    {
        instance = this;
        myCam = gameObject.GetComponent<Camera>();
    }

    private void OnPostRender()
    {
        if (takeScreenshotNextFrame)
        {
            takeScreenshotNextFrame = false;
            RenderTexture renderTexture = myCam.targetTexture;

            Texture2D renderResult = new(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);
            
            
            string fileName = "SavedImage" + screenshotCounter.ToString("D2") + ".png";
            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/Gallery/" + fileName, byteArray);
            Debug.Log("Saved Image: " + fileName);
            screenshotCounter++;
            
            RenderTexture.ReleaseTemporary(renderTexture);
            myCam.targetTexture = null;
        }
    }

    private void TakeScreenshot(int width, int height)
    {
        myCam.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenshotNextFrame = true;
    }

    public static void TakeScreenshot_Static(int width, int height)
    {
        instance.TakeScreenshot(width, height);
    }
}
