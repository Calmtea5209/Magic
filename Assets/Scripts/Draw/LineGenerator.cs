using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mediapipe.Unity;
using Mediapipe.Unity.HandTracking;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    public Camera customCamera; 
    public float lineDistance = 2f; 
    public static int choose = 0;
    public GameObject HandTracking;
    public static Line activeLine;
    public static bool isDrawing = false;
    public static bool start = false;
    public static bool stop = false;

    void Update()
    {
        if (!isDrawing && Input.GetKeyDown(KeyCode.V) && !ControlCanvas.SettingMenuStatus)
        {
            start = true;
            stop = false;
            if(choose == 1)
            {
                HandTracking.SetActive(true);
            }
            isDrawing = true;
        }
        else if (isDrawing && Input.GetKeyDown(KeyCode.V))
        {
            start = false;
            stop = true;
            if(choose == 1)
            {
                //HandTracking.SetActive(false);
                
            }
            isDrawing = false;
            Line[] lines = FindObjectsOfType<Line>();
            foreach (Line line in lines)
            {
                Destroy(line.gameObject);
            }
        }

        if (choose == 0 && isDrawing && Input.GetMouseButtonDown(0) || choose == 1 && isDrawing && Input.GetKeyDown(KeyCode.R))
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

        if (choose == 0 && isDrawing && Input.GetMouseButtonUp(0) || choose == 1 && isDrawing && Input.GetKeyUp(KeyCode.R))
        {
            activeLine = null;
        }

        if (isDrawing && activeLine != null)
        {
            if(choose == 0)
            {
                Vector3 mousePos = customCamera.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * lineDistance);
                activeLine.UpdateLine(mousePos);
            }
            else
            {
                Vector3 handPos = customCamera.ScreenToWorldPoint(HandTrackingSolution.fingerPosition + Vector3.forward * lineDistance);
                activeLine.UpdateLine(handPos);
            }
        }
    }
}
