using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSaver : MonoBehaviour
{
    
    public void SaveImage()
    {
        Debug.Log("Help?");
        SaveDrawing.TakeScreenshot_Static(500,500);
    }
}
