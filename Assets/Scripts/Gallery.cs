using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Gallery : MonoBehaviour
{
    public GameObject thumbnailPrefab;
    public Transform galleryPanel;
    [SerializeField] GameObject bigDisplay; 

    private void Start()
    {
        string userDirectoryPath = User.Instance.UserDirectoryPath;
        string[] photoPaths = Directory.GetFiles(userDirectoryPath, "*.png");

        if (photoPaths.Length > 0)
        {
            foreach (string photoPath in photoPaths)
            {
                byte[] imageBytes = File.ReadAllBytes(photoPath);
                Texture2D photoTexture = new Texture2D(2, 2);
                photoTexture.LoadImage(imageBytes);
                GameObject thumbnail = Instantiate(thumbnailPrefab, galleryPanel);
                Image thumbnailImage = thumbnail.GetComponent<Image>();
                thumbnailImage.sprite = Sprite.Create(photoTexture, new Rect(0, 0, photoTexture.width, photoTexture.height), Vector2.one * 0.5f);
            }
        }
        else
        {
            CloseBigDisplay();
        }
    }

    public void CloseBigDisplay()
    {
        bigDisplay.SetActive(false);
    }
}
