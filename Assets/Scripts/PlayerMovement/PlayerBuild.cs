using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuild : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera mainCamera;
    [SerializeField]
    private CinemachineVirtualCamera deskCamera = null;

    public static bool isMain = false;
    public static bool isBuilding = false;

    public static bool isDeskArea = false;

    private void OnEnable()
    {
        CameraSwitcher.Register(mainCamera);
        if(deskCamera != null)
        {
            CameraSwitcher.Register(deskCamera);
        }
        CameraSwitcher.SwitchCamera(mainCamera);
        isMain = true;
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(mainCamera);
        if (deskCamera != null)
        {
            CameraSwitcher.Unregister(deskCamera);
        }
    }


    private void Update()
    {
  
        if (Input.GetKeyDown(KeyCode.F) && isDeskArea)
        {
            if (CameraSwitcher.isActiveCamera(mainCamera) && deskCamera!= null)
            {
                CameraSwitcher.SwitchCamera(deskCamera);
                isMain = false;
                isBuilding = true;
            }
            else {
                CameraSwitcher.SwitchCamera(mainCamera);
                isMain = true;
                isBuilding = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Desk"))
        {
            isDeskArea = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Desk"))
        {
            isDeskArea = false;
        }
    }

}
