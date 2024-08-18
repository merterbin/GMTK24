using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerControl : MonoBehaviour
{
    [SerializeField] Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered");
            anim.Play("DoorOpen", 0, 0.0f);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited");
            anim.Play("DoorClose", 0, 0.0f);
        }
    }

}
