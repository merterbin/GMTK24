using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public float sensX, sensY;
    public Transform orientation;
    float rotX, rotY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (PlayerBuild.isMain)
        {
            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

            rotY += mouseX;
            rotX -= mouseY;
            rotX = Mathf.Clamp(rotX, -90f, 90f);

            transform.localRotation = Quaternion.Euler(rotX, rotY, 0f);
            orientation.rotation = Quaternion.Euler(0f, rotY, 0f);
        }    
    }
}
