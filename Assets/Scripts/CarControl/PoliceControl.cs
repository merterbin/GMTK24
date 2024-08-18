using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class PoliceControl : MonoBehaviour
{
    private NavMeshAgent _navMashCar;
    public Collider _collider;
    public Rigidbody _rb;
    public float safeDistance = 4f ;
    private bool flagresume = true;
    // Start is called before the first frame update
    void Start()
    {
        _navMashCar = GetComponent<NavMeshAgent>();
        _collider = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] nearbyVehicles = Physics.OverlapSphere(transform.position, safeDistance);

        safeDistance = 2.8f;
        foreach (Collider vehicle in nearbyVehicles)
        {

            if (  ( (vehicle.CompareTag("Player") || (vehicle.CompareTag("Car")) && (vehicle.gameObject != gameObject) )))
            {
                // Araçlar arasýndaki mesafeyi kontrol et ve gerektiðinde yönünü deðiþtir

                Vector3 direction = transform.position - vehicle.transform.position;

                if (direction.magnitude < safeDistance)
                {
                    _navMashCar.speed = 0f;
                    flagresume = false;
                    Invoke("ResumeMovement", 3f);
                    //_navMashCar.SetDestination(transform.position + direction.normalized * safeDistance);
                }
            }
        }
    }
    void ResumeMovement()
    {
        
        if ( !flagresume && _navMashCar != null)
        {
            _navMashCar.speed = 4f;
            Invoke("ChangeSafeDistance", 0.7f);
            flagresume = true;
        }
    }
    void ChangeSafeDistance()
    {
        safeDistance = 0f;
    }
}
