using UnityEngine;
using System.IO;
using Firebase.Extensions;
using Firebase.Storage;

public class UploadFile : MonoBehaviour
{
    FirebaseStorage storage;
    StorageReference storageReference;
    [SerializeField] DrawingUIController uiControl;

    void Start()
    {
        storage = FirebaseStorage.DefaultInstance;
        storageReference = storage.GetReferenceFromUrl("gs://draw-patrol.appspot.com");
    }

    public void UploadImageFromPath(string filePath, string fileName)
    {
        if (File.Exists(filePath))
        {
            byte[] imageBytes = File.ReadAllBytes(filePath);

            UploadImage(imageBytes, fileName);
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }

    private void UploadImage(byte[] imageBytes, string fileName)
    {
        uiControl.ShowSendingNowText();
        var newMetadata = new MetadataChange();
        newMetadata.ContentType = "image/png";

        StorageReference uploadRef = storageReference.Child("uploads/" + User.Instance.UserId + "/" + fileName);
        Debug.Log("File upload started");
        uploadRef.PutBytesAsync(imageBytes, newMetadata).ContinueWithOnMainThread((task) => {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.Log(task.Exception.ToString());
            }
            else
            {
                Debug.Log("File Uploaded Successfully!");
                uiControl.OpenSentCompletePopup();
            }
        });
    }

    public void OnUploadButtonPressed() => Invoke(nameof(DelayedUpload), 0.5f);

    private void DelayedUpload()
    {
        Debug.Log(User.Instance.NumberOfDrawings);
        string fileName = User.Instance.NumberOfDrawings + ".png";
        string filePath = Path.Combine(User.Instance.UserDirectoryPath, fileName);

        UploadImageFromPath(filePath, fileName);
        User.Instance.IncrementNumberOfDrawings();
    }
}
