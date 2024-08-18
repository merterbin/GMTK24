using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> placedGameObject = new();

    [SerializeField]
    private GameObject startLocation;

    [SerializeField]
    private ScaleBuildingSystem scaleBuildingSystem;

    public int PlaceObject(GameObject prefab, Vector3 position)
    {
        GameObject newObject = Instantiate(prefab);
        newObject.transform.position = position;
        placedGameObject.Add(newObject);
        TriggerScaleBuilding(CalculateGridPosition(startLocation, newObject), prefab);
        return placedGameObject.Count - 1;
    }

    public void RemoveObjectAt(int gameObjectIndex)
    {
        if (placedGameObject.Count <= gameObjectIndex
            || placedGameObject[gameObjectIndex] == null)
            return;
        Destroy(placedGameObject[gameObjectIndex]);
        placedGameObject[gameObjectIndex] = null;
    }

    public Vector3 CalculateGridPosition(GameObject startLocation, GameObject obj)
    {
        Vector3 gridPosition = startLocation.transform.InverseTransformPoint(obj.transform.position);

        return gridPosition;
    }
    
    public void TriggerScaleBuilding(Vector3 gridPosition, GameObject prefab)
    {
        if(scaleBuildingSystem != null)
        {
            scaleBuildingSystem.AddItem(gridPosition,prefab);
        }

    }

}
