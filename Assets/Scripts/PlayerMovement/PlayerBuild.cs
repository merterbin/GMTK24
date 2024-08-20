using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuild : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera mainCamera;
    [SerializeField]
    public CinemachineVirtualCamera deskCamera = null;

    [SerializeField]
    private GameObject buildPanel;

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
  
        if (Input.GetKeyDown(KeyCode.E) && isDeskArea)
        {
            if (CameraSwitcher.isActiveCamera(mainCamera) && deskCamera!= null)
            {
                buildPanel.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                CameraSwitcher.SwitchCamera(deskCamera);
                isMain = false;
                isBuilding = true;
            }
            else {
                CameraSwitcher.SwitchCamera(mainCamera);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                isMain = true;
                isBuilding = false;
                buildPanel.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Desk"))
        {
            Debug.Log("desk");
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
