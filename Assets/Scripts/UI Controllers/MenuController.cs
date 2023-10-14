using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject drawingMenu;
    [SerializeField] GameObject sketchesMenu;
    [SerializeField] GameObject galleryMenu;

    public void ActivateMenu(GameObject menuToActivate)
    {
        mainMenu.SetActive(false);
        drawingMenu.SetActive(false);
        sketchesMenu.SetActive(false);
        galleryMenu.SetActive(false);

        menuToActivate.SetActive(true);
    }
}
