using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public static Color currentColor = Color.black;

    public void SetColor(string colorHex)
    {
        Color newColor;
        if (ColorUtility.TryParseHtmlString(colorHex, out newColor))
        {
            currentColor = newColor;
        }
    }
}
