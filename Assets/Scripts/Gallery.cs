using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Gallery : MonoBehaviour
{
    public GameObject thumbnailPrefab; // Reference to the thumbnail prefab
    public Transform galleryPanel; // Parent object for the thumbnails

    private void Start()
    {
        // Access the user's local directory
        string userDirectoryPath = User.Instance.UserDirectoryPath;

        // List all photo files in the user's directory
        string[] photoPaths = Directory.GetFiles(userDirectoryPath, "*.png");

        // Instantiate thumbnails for each photo
        foreach (string photoPath in photoPaths)
        {
            // Load the photo as a texture
            byte[] imageBytes = File.ReadAllBytes(photoPath);
            Texture2D photoTexture = new Texture2D(2, 2);
            photoTexture.LoadImage(imageBytes);

            // Instantiate the thumbnail prefab
            GameObject thumbnail = Instantiate(thumbnailPrefab, galleryPanel);

            // Assign the loaded image to the thumbnail's Image component
            Image thumbnailImage = thumbnail.GetComponent<Image>();
            thumbnailImage.sprite = Sprite.Create(photoTexture, new Rect(0, 0, photoTexture.width, photoTexture.height), Vector2.one * 0.5f);

            // You can set the thumbnail's position and other properties as needed
        }
    }
}