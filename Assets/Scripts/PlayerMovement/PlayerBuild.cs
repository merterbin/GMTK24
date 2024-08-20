using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuild : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera mainCamera;
    [SerializeField]
    public CinemachineVirtualCamera deskCamera1 = null;
    [SerializeField]
    public CinemachineVirtualCamera deskCamera2 = null;

    [SerializeField]
    private PlayerTrigger Ptrigger;

    [SerializeField]
    private GameObject buildPanel1;
    [SerializeField]
    private GameObject buildPanel2;

    public static bool isMain = false;
    public static bool isBuilding = false;
    public static bool isDeskArea = false;

    [SerializeField]
    private GameObject focusButtonPanel;
    [SerializeField]
    private GameObject BuildButtonPanel;


    [SerializeField]
    private ObjectPlacer SquarePlacer;
    [SerializeField]
    private ObjectPlacer ReactangalePlacer;

    [SerializeField]
    public List<ScaleBuildingSystem> buildingSystems;


    private void OnEnable()
    {
        CameraSwitcher.Register(mainCamera);
        if(deskCamera1 != null)
        {
            CameraSwitcher.Register(deskCamera1);
        }
        if (deskCamera2 != null)
        {
            CameraSwitcher.Register(deskCamera2);
        }
        CameraSwitcher.SwitchCamera(mainCamera);
        isMain = true;
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(mainCamera);
        if (deskCamera1 != null)
        {
            CameraSwitcher.Unregister(deskCamera1);
        }
        if (deskCamera2 != null)
        {
            CameraSwitcher.Unregister(deskCamera2);
        }
    }


    private void Update()
    {
  
        if (Input.GetKeyDown(KeyCode.E) && isDeskArea)
        {

            if (CameraSwitcher.isActiveCamera(mainCamera))
            {
                if ((Ptrigger.job == "SignPlane1" || Ptrigger.job == "SignPlane4") && deskCamera1 != null)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    buildPanel1.SetActive(true);
                    CameraSwitcher.SwitchCamera(deskCamera1);
                    isMain = false;
                    isBuilding = true;

                }
                else if ((Ptrigger.job == "SignPlane2" || Ptrigger.job == "SignPlane3") && deskCamera2 != null)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    buildPanel2.SetActive(true);
                    CameraSwitcher.SwitchCamera(deskCamera2);
                    isMain = false;
                    isBuilding = true;
                }  
            }
            else {
                CameraSwitcher.SwitchCamera(mainCamera);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                isMain = true;
                isBuilding = false;
                buildPanel1.SetActive(false);
                buildPanel2.SetActive(false);
            }
        }
        else if(Input.GetKeyDown(KeyCode.B) && isDeskArea)
        {
            Build();
        }


    

        if(!isBuilding && isDeskArea)
        {
            focusButtonPanel.SetActive(true);
            BuildButtonPanel.SetActive(true);
        }
        else
        {
            focusButtonPanel.SetActive(false);
            BuildButtonPanel.SetActive(false);
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


    public void Build()
    {
        if ((Ptrigger.job == "SignPlane1" || Ptrigger.job == "SignPlane4") && !isBuilding)
        {
            for(int i = 0; i < SquarePlacer.placedGameObject.Count; i++)
            {
                if (SquarePlacer.placedGameObject[i] != null)
                {
                    if (SquarePlacer.positionGameObject[i] != null)
                    {
                        if(Ptrigger.job == "SignPlane1")
                        {
                            buildingSystems[0].AddItem(SquarePlacer.positionGameObject[i], SquarePlacer.placedGameObject[i]);
                            Ptrigger.Jobs[0] = true;
                            Ptrigger.enableSigns();
                        }
                        else
                        {
                            buildingSystems[3].AddItem(SquarePlacer.positionGameObject[i], SquarePlacer.placedGameObject[i]);
                            Ptrigger.Jobs[3] = true;
                            Ptrigger.enableSigns();
                        }
                    }
                }
            }
            DestroyALL(SquarePlacer.placedGameObject);

        }
        else if ((Ptrigger.job == "SignPlane2" || Ptrigger.job == "SignPlane3") && !isBuilding)
        {
            for (int i = 0; i < ReactangalePlacer.placedGameObject.Count; i++)
            {
                if (ReactangalePlacer.placedGameObject[i] != null)
                {
                    if (ReactangalePlacer.positionGameObject[i] != null)
                    {
                        if (Ptrigger.job == "SignPlane2")
                        {
                            buildingSystems[1].AddItem(ReactangalePlacer.positionGameObject[i], ReactangalePlacer.placedGameObject[i]);
                            Ptrigger.Jobs[1] = true;
                            Ptrigger.enableSigns();
                        }
                        else
                        {
                            buildingSystems[2].AddItem(ReactangalePlacer.positionGameObject[i], ReactangalePlacer.placedGameObject[i]);
                            Ptrigger.Jobs[2] = true;
                            Ptrigger.enableSigns();
                        }
                    }
                }
            }
            DestroyALL(ReactangalePlacer.placedGameObject);
        }

    }

    public void DestroyALL(List<GameObject> gbs)
    {
        foreach(GameObject gb in gbs)
        {
            if(gb != null)
                Destroy(gb);
        }
    }

}
