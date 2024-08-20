using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public void goHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        
    }
    private void Update()
    {
        if (isExit)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                StartButton();
                isExit = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
            {
                PauseButton();
                isExit = true;
            }
    }

}
