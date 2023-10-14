using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SketchController : MonoBehaviour
{
    public Sprite sketch;
    private SceneController sceneController;

    private void Start()
    {
        sceneController = GameObject.FindObjectOfType<SceneController>();
        if (sceneController == null)
        {
            Debug.LogError("SceneController not found in the scene.");
        }
    }

    public void ChooseSketch()
    {
        SketchManager.Instance.SelectedSketch = sketch;
        if (sceneController != null)
        {
            sceneController.LoadSceneByIndex(1);
        }
    }
}
