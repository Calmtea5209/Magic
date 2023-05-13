using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;

    List<Vector3> points; 

    public void UpdateLine(Vector3 position)
    {
        if (points == null)
        {
            points = new List<Vector3>();
            SetPoint(position);
            return;
        }

        if (Vector3.Distance(points[points.Count - 1], position) > .1f)
        {
            SetPoint(position);
        }
    }

    void SetPoint(Vector3 point)
    {
        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);
    }
}
