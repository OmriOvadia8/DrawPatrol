using UnityEngine;

public class ImageSaver : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int height;
    public void SaveImage()
    {
        SaveDrawing.TakeScreenshot_Static(width,height);
    }
}
