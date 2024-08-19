using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float speed = 10f; 
    public Vector3 direction = Vector3.forward; 

    private bool shouldMove = false;

    void Update()
    {

        if (shouldMove)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            Invoke("StartMovement", 1.1f);
        }

    }
    public void StartMovement()
    {
        shouldMove = true;
    }
}
