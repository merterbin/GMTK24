
using UnityEngine;
using UnityEngine.AI;

public class NavMashCar : MonoBehaviour
{
    public GameObject[] waypoints;
    NavMeshAgent _navMashCar;
    public int waypointsIndex = 0;

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
}