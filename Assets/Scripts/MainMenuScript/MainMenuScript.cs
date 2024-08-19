using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public float movementduration = 1.3f;
    public void PlayButton()
    {
        StartCoroutine(StopAndLoadNextScene());
    }
    private IEnumerator StopAndLoadNextScene()
    {
        yield return new WaitForSeconds(movementduration); // Belirtilen süre kadar bekle
        SceneManager.LoadScene(2); // Diðer sahneyi yükle ("NextSceneName" yerine sahne adýný yaz)
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void Settings()
    {
        SceneManager.LoadScene(1);
    }
}
