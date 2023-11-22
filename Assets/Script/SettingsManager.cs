using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    [SerializeField] private Slider volumeSlider;
    [SerializeField] private GameObject SettingsPanel;

    private float currentVolume = 1;

    private void Awake()
    {
        InitVolume();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettings();
        }
    }

    public void ToggleSettings()
    {
        SettingsPanel.SetActive(!SettingsPanel.activeSelf);
    }

    //volume
    private void InitVolume()
    {
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", currentVolume);
        }
        else
        {
            currentVolume = PlayerPrefs.GetFloat("Volume");
        }
        volumeSlider.value = currentVolume;
        AudioListener.volume = currentVolume;
    }

    public void SetVolume(float value)
    {
        currentVolume = value;
        PlayerPrefs.SetFloat("Volume", currentVolume);
        AudioListener.volume = currentVolume;
    }
}
