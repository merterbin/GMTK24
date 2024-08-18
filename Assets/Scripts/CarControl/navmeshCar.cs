using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.AI;

public class NavMashCar : MonoBehaviour
{
    public GameObject[] waypoints;
    NavMeshAgent _navMashCar;
    public int waypointsIndex = 1;

    void Start()
    {
        _navMashCar = GetComponent<NavMeshAgent>();
        Rigidbody rb = GetComponent<Rigidbody>();
        Collider collider = rb.GetComponent<Collider>();
        if (waypoints.Length > 0)
        {
            _navMashCar.SetDestination(waypoints[waypointsIndex].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        goAroundwaypoints();
    }
    public void goAroundwaypoints()
    {
        if (_navMashCar.remainingDistance < 0.5f && !_navMashCar.pathPending)
        {
            if (waypointsIndex >= waypoints.Length)
            {
                waypointsIndex = 1;
            }
            else
            {
                waypointsIndex = waypointsIndex + 1;
            }
            _navMashCar.SetDestination(waypoints[waypointsIndex - 1].transform.position);

        }
    }
    //void checkDistance()
    //{
    //    RaycastHit hit;
    //    for (int i = 0; i < frontCheck.Length; i++)
    //    {

    //        if (Physics.Raycast(frontCheck[i].position, transform.forward, out hit, stoppingDistance))
    //        {
    //            Debug.Log("BULDU");
    //            if (hit.collider.CompareTag("Car"))
    //            {
    //                Debug.Log("ARABA BULDU");
    //                _navMashCar.speed = 0f;
    //            }
    //        }
    //        else
    //        {
    //            goAroundwaypoints();
    //            _navMashCar.speed = 5f;
    //        }
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Police") || collision.gameObject.CompareTag("sedan"))
        {
            this._navMashCar.speed = 0f;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Police") || collision.gameObject.CompareTag("sedan"))
        {
            this._navMashCar.speed = 4f;
        }
    }

}