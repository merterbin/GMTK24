using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.3f; 
    public Vector3 direction = Vector3.forward; 

    private bool shouldMove = false;

    void Update()
    {

        if (shouldMove)
        {
            transform.Translate(direction * speed * Time.deltaTime);

            
            Invoke("StartMovement", 1.3f);
        }

    }
    public void StartMovement()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), 0.2f * Time.deltaTime);
        shouldMove = true;
    }
}
