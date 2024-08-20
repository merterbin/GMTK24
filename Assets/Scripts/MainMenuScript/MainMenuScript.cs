using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public float movementduration = 1.3f;
    public GameObject canvas;
    public GameObject settingCanvas;
    public void QuitButton()
    {
        Application.Quit();
    }
    public void Settings()
    {
        StartCoroutine (WaitForAnimation());
        
    }
    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        settingCanvas.SetActive(true);
        canvas.SetActive(false);
    }
}
