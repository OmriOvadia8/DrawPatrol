using UnityEngine;
using UnityEngine.UI;

public class LineSettings : MonoBehaviour
{
    public static Color CurrentColor = Color.black;
    public static float CurrentWidth = 0.1f;
    [SerializeField] Slider widthSlider;
    [SerializeField] RectTransform handleTransform;
    [SerializeField] Image handleImage;

    void Start()
    {
        widthSlider.value = CurrentWidth;
        widthSlider.onValueChanged.AddListener(UpdateLineWidth);
        UpdateHandleSize(widthSlider.value);
    }

    public void SetColor(string colorHex)
    {
        if (ColorUtility.TryParseHtmlString(colorHex, out Color newColor))
        {
            CurrentColor = newColor;
            handleImage.color = CurrentColor;
        }
    }

    public void UpdateLineWidth(float newWidth)
    {
        CurrentWidth = newWidth;
        UpdateHandleSize(newWidth);
    }

    public void SetSliderValue() => widthSlider.value = CurrentWidth;

    void UpdateHandleSize(float sliderValue)
    {
        float newScale = Mathf.Lerp(0.75f, 1.75f, sliderValue);
        handleTransform.localScale = new Vector3(newScale, newScale, newScale);
    }
}
