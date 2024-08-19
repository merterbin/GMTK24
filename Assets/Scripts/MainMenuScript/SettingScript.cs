using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    public Slider slider;
    private float volume = 0;
    // Start is called before the first frame update
    public AudioMixer audioMixer;
    public void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            slider.value = savedVolume;
            SetVolume(volume);
        }
        //else
        //{
        //    slider.value = 0f;
        //}
        slider.onValueChanged.AddListener(SetVolume);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }
    public void closeSettings()
    {
        SceneManager.LoadScene(0);
    }
    void Awake()
    {
        DontDestroyOnLoad(slider); // Bu obje sahneler arasýnda yok edilmez
    }
}
