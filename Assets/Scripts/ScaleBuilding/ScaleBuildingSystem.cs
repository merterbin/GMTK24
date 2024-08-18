using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBuildingSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject ScaleBuilding;

    [SerializeField]
    private ObjectsDatabaseSO database;


    public void AddItem(Vector3 gridPosition, GameObject prefab)
    {
        GameObject scaleObject = Instantiate(prefab);
        scaleObject.transform.SetParent(ScaleBuilding.transform);
        scaleObject.transform.position = gridPosition * 4;
        scaleObject.transform.position = scaleObject.transform.position + new Vector3(50f, 0f, 0f);
        scaleObject.transform.localScale = new Vector3(4f, 1f, 4f);
    }

    
}
