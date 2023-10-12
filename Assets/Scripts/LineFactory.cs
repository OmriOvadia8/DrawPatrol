using UnityEngine;

public class LineFactory : MonoBehaviour
{
    public GameObject linePrefab;
    Line activeLine;
    private int currentSortingOrder = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newLine = Instantiate(linePrefab);
            activeLine = newLine.GetComponent<Line>();
            activeLine.GetComponent<LineRenderer>().sortingOrder = currentSortingOrder++; 
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
    }
}
