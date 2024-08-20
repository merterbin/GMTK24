using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTrigger : MonoBehaviour
{
    private bool inArea = false;
    private GameObject collisonPlane = null;

    [SerializeField]
    public string job = "";
    private bool takeJob = false;

    [SerializeField] 
    TextMeshProUGUI progressText;

    [SerializeField]
    private List<GameObject> sings = null;

    private void Start()
    {
        progressText.text = "Go around the city and take one job.";
    }

    void Update()
    {
        if (collisonPlane != null && inArea)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!takeJob)
                {
                    progressText.text = "Go to your office.";
                    takeJob = true;
                    job = collisonPlane.name;
                    disableSings(collisonPlane.tag);
                }
        
            }
        }  
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane1Trigger"))
        {
            inArea = true;
            collisonPlane = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag("Plane2Trigger"))
        {
            inArea = true;
            collisonPlane = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag("Plane3Trigger"))
        {
            inArea = true;
            collisonPlane = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag("Plane4Trigger"))
        {
            inArea = true;
            collisonPlane = collision.gameObject;
        }   
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane1Trigger"))
            inArea = false;
        else if (collision.gameObject.CompareTag("Plane2Trigger"))
            inArea = false;
        else if (collision.gameObject.CompareTag("Plane3Trigger"))
            inArea = false;
        else if (collision.gameObject.CompareTag("Plane4Trigger"))
            inArea = false;

        collisonPlane = null;
    }

    private void disableSings(string tag)
    {
        foreach(GameObject g in sings)
        {
            if (!g.CompareTag(tag))
            {
                g.SetActive(false);
            }
        }
    }

}
