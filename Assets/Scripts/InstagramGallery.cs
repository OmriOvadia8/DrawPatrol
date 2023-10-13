using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstagramGallery : MonoBehaviour
{
    public string instagramURL = "https://www.instagram.com/drawpatrol/";

    public void OpenInstagram() 
    {
        Application.OpenURL(instagramURL);
    }
}
