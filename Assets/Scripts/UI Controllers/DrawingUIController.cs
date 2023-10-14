using UnityEngine;
using UnityEngine.UI;

public class DrawingUIController : MonoBehaviour
{
    [SerializeField] private GameObject sendPopup;
    [SerializeField] private GameObject savePopup;
    [SerializeField] private GameObject sentCompletePopup;
    [SerializeField] private GameObject sendingText;
    [SerializeField] private Button saveButton;
    [SerializeField] private Button backToMenuButton;

    private void Start() => ResetUI();

    private void ResetUI()
    {
        sendingText.SetActive(false);
        savePopup.SetActive(false);
        sendPopup.SetActive(false);
        sentCompletePopup.SetActive(false);
        saveButton.interactable = true;
    }

    public void OpenSentCompletePopup()
    {
        ResetUI();
        sentCompletePopup.SetActive(true);
        saveButton.interactable = false;
    }

    public void OpenSendPopup()
    {
        ResetUI();
        sendPopup.SetActive(true);
        saveButton.interactable = false;
    }

    public void OpenSavePopup()
    {
        ResetUI();
        savePopup.SetActive(true);
        saveButton.interactable = false;
    }

    public void CloseSavePopup() => ResetUI();

    public void ShowSendingNowText()
    {
        sendingText.SetActive(true);
    }
}
