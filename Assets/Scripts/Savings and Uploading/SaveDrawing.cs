using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveDrawing : MonoBehaviour
{
    private static SaveDrawing instance;
    private Camera myCam;
    private bool takeScreenshotNextFrame;


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

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);
            
            string fileName = User.Instance.NumberOfDrawings + ".png";
            byte[] byteArray = renderResult.EncodeToPNG();
            string filePath = Path.Combine(User.Instance.UserDirectoryPath, fileName);
            File.WriteAllBytes(filePath, byteArray); 
            Debug.Log("Saved Image: " + fileName);

            RenderTexture.ReleaseTemporary(renderTexture);
            myCam.targetTexture = null;
        }
    }

    private void TakeScreenshot(int width, int height)
    {
        myCam.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenshotNextFrame = true;
    }

    public static void TakeScreenshot_Static(int width, int height) => instance.TakeScreenshot(width, height);
}