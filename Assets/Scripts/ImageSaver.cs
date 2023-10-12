using UnityEngine;

public class ImageSaver : MonoBehaviour
{
    
    public void SaveImage()
    {
        SaveDrawing.TakeScreenshot_Static(1024,500);
    }
}
