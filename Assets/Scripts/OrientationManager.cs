using UnityEngine;
using UnityEngine.SceneManagement;

public class OrientationManager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SetOrientation();
    }

    void OnLevelWasLoaded(int level) => SetOrientation();

    void SetOrientation()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 

        if (currentSceneIndex == 0) 
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        else if (currentSceneIndex == 1) 
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft; 
        }
    }
}
