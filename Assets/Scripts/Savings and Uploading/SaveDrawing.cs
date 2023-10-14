using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveDrawing : MonoBehaviour
{
    private static SaveDrawing instance;
    private Camera myCam;
    private bool takeScreenshotNextFrame;
    private int screenshotCounter = 1;

    private List<DrawingInfo> savedDrawings = new List<DrawingInfo>();
    public DrawingInfo curr_drawing;

    private string saveDirectory;
    private string userKey;


    [Serializable]
    public class DrawingInfo
    {
        public string fileName;
        public DateTime saveTime;
        public bool sendToSoldiers;
    }

    private void Start()
    {
        // userKey = PlayerPrefs.GetString("UserKey");
        // if (string.IsNullOrEmpty(userKey))
        // {
        //     userKey = System.Guid.NewGuid().ToString();
        //     PlayerPrefs.SetString("UserKey", userKey);
        //     PlayerPrefs.Save(); // Save the PlayerPrefs data
        // }
        //
        // // Initialize the save directory
        // saveDirectory = Path.Combine(Application.persistentDataPath, userKey);
        // // Create the directory if it doesn't exist
        // if (!Directory.Exists(saveDirectory))
        // {
        //     Directory.CreateDirectory(saveDirectory);
        // }
        
    }

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
            File.WriteAllBytes(filePath, byteArray); // changed to use the saveDirectory
            Debug.Log("Saved Image: " + fileName);

            DrawingInfo drawingInfo = new DrawingInfo
            {
                fileName = fileName,
                saveTime = DateTime.Now,
                sendToSoldiers = false
            };
            savedDrawings.Add(drawingInfo);
            curr_drawing = drawingInfo;

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