using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{

    [SerializeField]
    public GameObject BigDisplayPrefab; 
    private Image thumbnailImage;
    private Image bigImg;

    private GameObject canvas;
    private GameObject bigDisplay;

    void Start()
    {
        // Find the Canvas
        canvas = GameObject.FindWithTag("UI");
    }
    
    public void DisplayBig()
    {
        thumbnailImage = this.GetComponent<Image>();
        
        // Instantiate the BigDisplayPrefab as a child of the Canvas
        bigDisplay = Instantiate(BigDisplayPrefab, canvas.transform);
    
        bigImg = bigDisplay.GetComponent<Image>();
        bigImg.sprite = thumbnailImage.sprite;
    }

    public void CloseBigDisplay()
    {
        if (bigDisplay != null)
        {
            Destroy(bigDisplay);
        }
    }
    
    public void OnCloseButtonClick()
    {
        CloseBigDisplay();
    }

    
}
