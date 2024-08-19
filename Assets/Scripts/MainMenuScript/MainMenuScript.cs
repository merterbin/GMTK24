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

    public Button yourButton;         // Butonun referansý
    public Animator yourAnimator;     // Animator referansý

    void Start()
    {
        // Buton týklama olayýný dinle
        //yourButton.onClick.AddListener(PlayAnimation);

    }

    

}
