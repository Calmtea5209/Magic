using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamara : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    float yRotation = 0f;

    public Transform player;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation += mouseX;
        yRotation -= mouseY;

        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(yRotation, xRotation, 0);
        player.rotation = Quaternion.Euler(0 ,xRotation, 0);
    }
}
