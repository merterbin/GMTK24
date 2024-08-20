using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseCanvas;
    public bool isExit = false;

   
    public void PauseButton()
    {
        PauseCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
       
    }
    public void StartButton()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    private void Update()
    {
        if (isExit)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StartButton();
                isExit = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseButton();
                isExit = true;
            }
    }

}
