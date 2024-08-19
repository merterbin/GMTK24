using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(2);
    } 
    public void QuitButton()
    {
        Application.Quit();
    }
    public void Settings()
    {
        SceneManager.LoadScene(1);
            // Animasyonu tetikle
            yourAnimator.Play("MainMenu");

    }

    public Button yourButton;         // Butonun referans�
    public Animator yourAnimator;     // Animator referans�

    void Start()
    {
        // Buton t�klama olay�n� dinle
        //yourButton.onClick.AddListener(PlayAnimation);

    }

    

}
