using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    public Camera customCamera; 
    public float lineDistance = 2f; 

    public static Line activeLine;
    public static bool isDrawing = false;

    void Update()
    {
        if (!isDrawing && Input.GetKeyDown(KeyCode.V))
        {
            isDrawing = true;
        }
        else if (isDrawing && Input.GetKeyDown(KeyCode.V))
        {
            isDrawing = false;
            Line[] lines = FindObjectsOfType<Line>();
            foreach (Line line in lines)
            {
                Destroy(line.gameObject);
            }
        }

        if (isDrawing && Input.GetMouseButtonDown(0))
        {
            // Vector3 cameraPos = customCamera.transform.position;
            // Vector3 cameraForward = customCamera.transform.forward;
            // Vector3 lineSpawnPos = cameraPos + cameraForward * lineDistance;
            // Debug.Log(cameraPos);
            // Debug.Log(lineSpawnPos);
            // Debug.Log(cameraForward);
            // GameObject newLine = Instantiate(linePrefab, lineSpawnPos, Quaternion.identity);
            GameObject newLine = Instantiate(linePrefab);
            activeLine = newLine.GetComponent<Line>();
        }

        if (isDrawing && Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (isDrawing && activeLine != null)
        {
            Vector3 mousePos = customCamera.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * lineDistance);
            activeLine.UpdateLine(mousePos);
        }
    }
}
