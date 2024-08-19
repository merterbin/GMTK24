using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBuildingSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject ScaleBuilding;

    [SerializeField]
    private ObjectsDatabaseSO database;

    [SerializeField]
    private Vector3 scale = Vector3.one;

    [SerializeField]
    private Vector3 position = Vector3.one;


    public void AddItem(Vector3 gridPosition, GameObject prefab)
    {
        GameObject scaleObject = Instantiate(prefab,ScaleBuilding.transform);
        //scaleObject.transform.SetParent(ScaleBuilding.transform,true);

        Vector3 originPosition = new Vector3(gridPosition.x * position.x, gridPosition.y * position.y, gridPosition.z * position.z);
        //scaleObject.transform.localPosition = scaleObject.transform.localPosition + new Vector3(50f,0f,10f);
        scaleObject.transform.localPosition = scaleObject.transform.localPosition + originPosition;

      
        scaleObject.transform.localScale = scale;
    }


    
}
