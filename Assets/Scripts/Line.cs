using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;

    private List<Vector2> points;

    public void UpdateLine(Vector2 position)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(position);
            return;
        }

        if (Vector2.Distance(points.Last(), position) > 0.1f)
        {
            SetPoint(position);
        }
    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);
        lineRenderer.startWidth = LineSettings.CurrentWidth;
        lineRenderer.endWidth = LineSettings.CurrentWidth;
        lineRenderer.startColor = LineSettings.CurrentColor;
        lineRenderer.endColor = LineSettings.CurrentColor;
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);
    }
}
