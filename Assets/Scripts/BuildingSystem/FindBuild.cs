using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBuild : MonoBehaviour
{
    [SerializeField]
    private PlayerTrigger Ptrigger;

    [SerializeField]
    private PlayerBuild Pbuild;

    [SerializeField]
    private GameObject ReactangalePanel;
    [SerializeField]
    private GameObject SquarePanel;

    [SerializeField]
    private CinemachineVirtualCamera ReactangaleCamera;

    [SerializeField]
    private CinemachineVirtualCamera SquareCamera;

    private void Start()
    {
        ReactangalePanel.SetActive(false);
        SquarePanel.SetActive(false);
    }

    private void Update()
    {
        if (Ptrigger.job != "")
        {
            if(Ptrigger.job == "SignPlane1" || Ptrigger.job == "SignPlane4")
            {
                ReactangalePanel.SetActive(false);
                SquarePanel.SetActive(true);
                Pbuild.deskCamera = SquareCamera;
                
            }
            else if (Ptrigger.job == "SignPlane2" || Ptrigger.job == "SignPlane3")
            {
                ReactangalePanel.SetActive(true);
                SquarePanel.SetActive(false);
                Pbuild.deskCamera = ReactangaleCamera;
            }
        }
    }

}
