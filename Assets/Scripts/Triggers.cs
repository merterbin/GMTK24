using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class Triggers : MonoBehaviour
{
    private bool isPlaying = false;
    private bool jobTaken;
    private bool isPressed = false;
    private bool inArea = false;
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
        if (Input.GetKeyDown(KeyCode.F) && inArea)
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
            inArea = true;
            Debug.Log("Player entered");
            if (isPressed && !isPlaying)
            {
               
                doorAnim.Play("DoorOpen", 0, 0.0f);
                //doorAnim.Play("DoorOpen", 0, 0.0f);
                progressText.text = "Your desk is upstairs.";
                isPlaying = true;
            }            
        }

        if (this.gameObject.tag == "Plane1Trigger" && isPlayer)
        {
            inArea = true;
            Debug.Log("Player entered Plane 1");
            if (isPressed && !jobTaken)
            {
                Transform parentSign = this.transform.parent;
                Destroy(parentSign.gameObject);
                jobTaken = true;
                progressText.text = "Go to the your office.";

                Debug.Log("Job taken " + jobTaken);
            }
            
        }
        else if (this.gameObject.tag == "Plane2Trigger" && isPlayer)
        {
            inArea = true;
            Debug.Log("Player entered Plane 2");
            if (isPressed && !jobTaken)
            {
                Transform parentSign = this.transform.parent;
                Destroy(parentSign.gameObject);
                jobTaken = true;
                progressText.text = "Go to the your office.";

            }
        }
        else if (this.gameObject.tag == "Plane3Trigger" && isPlayer)
        {
            inArea = true;
            Debug.Log("Player entered Plane 3");
            if (isPressed && !jobTaken)
            {   
                jobTaken = true;
                Transform parentSign = this.transform.parent;
                Destroy(parentSign.gameObject);
                progressText.text = "Go to the your office.";

            }
        }
        else if (this.gameObject.tag == "Plane4Trigger" && isPlayer)
        {
            inArea = true;
            Debug.Log("Player entered Plane 4");
            if (isPressed && !jobTaken)
            {   
                jobTaken = true;
                Transform parentSign = this.transform.parent;
                Destroy(parentSign.gameObject);
                progressText.text = "Go to the your office.";

            }
        }
        else if (this.gameObject.tag == "Plane5Trigger" && isPlayer)
        {
            inArea = true;
            Debug.Log("Player entered Plane 5");
            if (isPressed && !jobTaken)
            {   
                jobTaken = true;
                Transform parentSign = this.transform.parent;
                Destroy(parentSign.gameObject);
                progressText.text = "Go to the your office.";

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
