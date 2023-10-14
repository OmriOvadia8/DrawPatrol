using UnityEngine;

public class SketchManager : MonoBehaviour
{
    public static SketchManager Instance { get; private set; }

    public Sprite SelectedSketch { get; set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
