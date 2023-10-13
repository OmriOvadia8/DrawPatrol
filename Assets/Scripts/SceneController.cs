using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadSceneByIndex(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
}
