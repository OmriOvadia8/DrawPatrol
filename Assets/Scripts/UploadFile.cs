using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//For firebase storage
using Firebase;
using Firebase.Extensions;
using Firebase.Storage;

public class UploadFile : MonoBehaviour
{
    FirebaseStorage storage;
    StorageReference storageReference;

    void Start()
    {
        storage = FirebaseStorage.DefaultInstance;
        storageReference = storage.GetReferenceFromUrl("gs://draw-patrol.appspot.com");
    }

    public void UploadImageFromPath(string filePath, string fileName)
    {
        // Check if file exists
        if (File.Exists(filePath))
        {
            // Read the file to bytes
            byte[] imageBytes = File.ReadAllBytes(filePath);

            // Call the upload method
            UploadImage(imageBytes, fileName);
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }

    private void UploadImage(byte[] imageBytes, string fileName)
    {
        var newMetadata = new MetadataChange();
        newMetadata.ContentType = "image/png";

        StorageReference uploadRef = storageReference.Child("uploads/" + fileName);
        Debug.Log("File upload started");
        uploadRef.PutBytesAsync(imageBytes, newMetadata).ContinueWithOnMainThread((task) => {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.Log(task.Exception.ToString());
            }
            else
            {
                Debug.Log("File Uploaded Successfully!");
            }
        });
    }

    public void OnUploadButtonPressed()
    {
        string fileName = "3.png"; // replace with your actual image file name
        string filePath = Application.persistentDataPath + "/Gallery/" + fileName;

        UploadImageFromPath(filePath, fileName);
    }
}
