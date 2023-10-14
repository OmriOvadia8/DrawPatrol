using System;
using System.IO;
using UnityEngine;

public class User
{
    public string UserId { get; private set; }
    public int NumberOfDrawings { get; private set; }
    public string UserDirectoryPath { get; private set; }

    private static User instance;

    private User()
    {
        UserId = PlayerPrefs.GetString("UserKey");
        if (string.IsNullOrEmpty(UserId))
        {
            UserId = System.Guid.NewGuid().ToString();
            PlayerPrefs.SetString("UserKey", UserId);
            PlayerPrefs.Save();
        }
        UserDirectoryPath = Path.Combine(Application.persistentDataPath, UserId);
        if (!Directory.Exists(UserDirectoryPath))
        {
            Directory.CreateDirectory(UserDirectoryPath);
        }

        NumberOfDrawings = 0;
    }

    public static User Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new User();
            }
            return instance;
        }
    }

    public void IncrementNumberOfDrawings()
    {
        NumberOfDrawings++;
    }
}