using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    private float volume = 0;
    // Start is called before the first frame update
    public GameObject canvas;
    public GameObject settingCanvas;
    public AudioMixer audioMixer;
    public void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {

            float savedVolume = PlayerPrefs.GetFloat("Volume");
            slider.value = savedVolume;
            SetVolume(volume);
        }
        slider.onValueChanged.AddListener(SetVolume);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }
    public void closeSettings()
    {
        canvas.SetActive(true);
        settingCanvas.SetActive(false);
    }
}
