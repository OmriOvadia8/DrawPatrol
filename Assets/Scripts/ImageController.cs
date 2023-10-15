using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    private Image thumbnailImage;
    private Image bigDisplay;

    private void Awake()
    {
        thumbnailImage = GetComponent<Image>();
        bigDisplay = GameObject.Find("Big Display").GetComponent<Image>();
    }

    void Start()
    {
        BigDisplaySetActive(false);
    }

    public void DisplayBig()
    {
        if (bigDisplay != null)
        {
            bigDisplay.sprite = thumbnailImage.sprite;
            BigDisplaySetActive(true);
            FirebaseManager.Instance.AnalyticsManager.ReportEvent(DPEventType.big_display);
        }
        else
        {
            Debug.LogError("Big Display object not found in the scene.");
        }
    }

    private void BigDisplaySetActive(bool value)
    {
        bigDisplay.gameObject.SetActive(value);
    }
}
