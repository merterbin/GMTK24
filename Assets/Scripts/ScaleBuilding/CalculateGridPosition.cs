using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateGridPosition : MonoBehaviour
{
    public GameObject pos1;
    public GameObject pos2;


    private void Start()
    {
        Vector3 objectALocalPosition = pos1.transform.InverseTransformPoint(pos2.transform.position);
        Debug.Log(objectALocalPosition);
    }

    private void Update()
    {
        Vector3 objectALocalPosition = pos1.transform.InverseTransformPoint(pos2.transform.position);
        Debug.Log("Row" + objectALocalPosition.x);
        Debug.Log("Col" + objectALocalPosition.z);
    }
}
