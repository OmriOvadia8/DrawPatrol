using UnityEngine;

public class SketchDisplayer : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer.sprite = SketchManager.Instance.SelectedSketch;
    }
}
