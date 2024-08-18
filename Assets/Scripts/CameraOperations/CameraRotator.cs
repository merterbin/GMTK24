using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{

    [SerializeField]
    private float rotateSpeed = 3f;

    [SerializeField]
    private KeyCode rotateLeft;
    [SerializeField]
    private KeyCode rotateRight;

    private bool isLeftRotate = false;
    private bool isRightRotate = false;

    void Update()
    {
        if (Input.GetKey(rotateRight) && !isLeftRotate)
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
            isRightRotate = true;
        }
        else if (Input.GetKey(rotateLeft) && !isRightRotate)
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
            isLeftRotate = true;
        }
        else
        {
            isLeftRotate = false;
            isRightRotate = false;
        }
    }
}
