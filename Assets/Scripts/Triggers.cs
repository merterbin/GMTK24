using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    private bool isPlaying = false;
    private bool jobTaken;
    private bool isPressed = false;
    private bool inArea = false;
    private bool inDoorArea = false;
    private bool isPlayer = false;
    [SerializeField] Animator doorAnim;
    [SerializeField] TextMeshProUGUI progressText;

    private void Start()
    {
        progressText.text = "Go around the city and take one job.";
    }
    private void Update()
    {
        Debug.Log("JobTaken: " + jobTaken);
        if (Input.GetKeyDown(KeyCode.F) && (inArea || inDoorArea))
        {
            Debug.Log("F key was pressed");
           
            isPressed = true;
            
        }
        else if (Input.GetKeyDown(KeyCode.F) && !inArea)
        {
            isPressed = false;
        }

    }
    
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayer = true;
        }
        if (this.gameObject.tag == "DoorInteract" && isPlayer)
        {
            Debug.Log("Is Playin: " + isPlaying);
            inDoorArea = true;
            if (isPressed && !isPlaying)
            {
                doorAnim.Play("DoorOpen", 0, 0.0f);
                isPlaying = true;
                //doorAnim.Play("DoorOpen", 0, 0.0f);
                progressText.text = "Your desk is upstairs.";
                
            }            
        }

        if (this.gameObject.tag == "Plane1Trigger" && isPlayer)
        {
            inArea = true;
            Debug.Log("Player entered Plane 1");
            if (isPressed && jobTaken == false )
            {                
                Transform parentSign = this.transform.parent;
                Destroy(parentSign.gameObject);
                progressText.text = "Go to your office.";
                jobTaken = true;
                Debug.Log("Job 1 taken ");
            }
            
        }
        else if (this.gameObject.tag == "Plane2Trigger" && isPlayer)
        {
            inArea = true;
            Debug.Log("Player entered Plane 2");
            if (isPressed && jobTaken == false)
            {
                Transform parentSign = this.transform.parent;
                Destroy(parentSign.gameObject);
                progressText.text = "Go to your office.";
                jobTaken = true;
                Debug.Log("Job 2 taken ");

            }
        }
        else if (this.gameObject.tag == "Plane3Trigger" && isPlayer)
        {
            inArea = true;
            Debug.Log("Player entered Plane 3");
            if (isPressed && !jobTaken)
            {   
                Transform parentSign = this.transform.parent;
                Destroy(parentSign.gameObject);
                progressText.text = "Go to your office.";
                jobTaken = true;
            }
        }
        else if (this.gameObject.tag == "Plane4Trigger" && isPlayer)
        {
            inArea = true;
            Debug.Log("Player entered Plane 4");
            if (isPressed && !jobTaken)
            {   
                Transform parentSign = this.transform.parent;
                Destroy(parentSign.gameObject);
                progressText.text = "Go to your office.";
                jobTaken = true;

            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        inArea = false;
        if (this.gameObject.tag == "DoorInteract")
        {
            Debug.Log("Player exited");
            doorAnim.Play("DoorClose", 0, 0.0f);
            isPlaying = false;
        }
        isPressed = false;
        
    }
    

}
