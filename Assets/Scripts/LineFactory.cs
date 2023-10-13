using UnityEngine;
using UnityEngine.EventSystems;


public class LineFactory : MonoBehaviour
{
    public GameObject linePrefab;
    Line activeLine;
    private int currentSortingOrder = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsPointerOverUIObject())
            {
                GameObject newLine = Instantiate(linePrefab);
                activeLine = newLine.GetComponent<Line>();
                activeLine.GetComponent<LineRenderer>().sortingOrder = currentSortingOrder++;                 
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector2 mousePos = Extensions.GetMouseWorldPosition();
            activeLine.UpdateLine(mousePos);
        }
    }
    
    
    private bool IsPointerOverUIObject()
    {
        // Check if the mouse pointer is over a UI element
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        // Raycast to determine if the pointer is over a UI object
        System.Collections.Generic.List<RaycastResult> results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }

}
