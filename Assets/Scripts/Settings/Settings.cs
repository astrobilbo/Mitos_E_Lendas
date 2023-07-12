using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public ColorBlindFilter colorBlindFilter;
    public ActiveNarrador activeNarrador;
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public TMP_Dropdown ColorDropdown;
    public Toggle fullScreenToggle;
    public Scrollbar sound;
    int colorID;
    Resolution[] resolutions;
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "hz";
            options.Add(option);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();
        fullScreenToggle.isOn = Screen.fullScreen;
        sound.value = PlayerPrefs.GetFloat("volume", sound.value);
        AudioManager.audioManager.musicAudioSourcer.volume = sound.value;
        AudioManager.audioManager.SFXAudioSourcer.volume = sound.value;
        AudioManager.audioManager.backgroundAudioSourcer.volume = sound.value;
        colorID = PlayerPrefs.GetInt("cor", colorID);
        SetColor(colorID);
        ColorDropdown.value = colorID;
        activeNarrador.activeNarrador = (PlayerPrefs.GetInt("activeNarrador") != 0);
    }
    public void SetVolume(float volume)
    {
        AudioManager.audioManager.musicAudioSourcer.volume = volume;
        AudioManager.audioManager.SFXAudioSourcer.volume = volume;
        AudioManager.audioManager.backgroundAudioSourcer.volume = volume;
    }

    public void SetQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetResolutions(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat("volume", sound.value);

    }
    public void SetNarrador(bool withNarrador)
    {
        activeNarrador.activeNarrador = withNarrador;
        PlayerPrefs.SetInt("activeNarrador", activeNarrador.activeNarrador ? 1 : 0);
    }
    public void SetColor(int color)
    {
        switch (color)
        {
            case 0:
                colorBlindFilter.mode = ColorBlindMode.Normal;
                print("Normal");

                break;
            case 1:
                colorBlindFilter.mode = ColorBlindMode.Protanopia;
                print("Protanopia");

                break;
            case 2:
                colorBlindFilter.mode = ColorBlindMode.Protanomaly;
                print("Protanomaly");

                break;
            case 3:
                colorBlindFilter.mode = ColorBlindMode.Deuteranopia;
                print("Deuteranopia");

                break;
            case 4:
                colorBlindFilter.mode = ColorBlindMode.Deuteranomaly;
                print("Deuteranomaly");

                break;
            case 5:
                colorBlindFilter.mode = ColorBlindMode.Tritanopia;
                print("Tritanopia");

                break;
            case 6:
                colorBlindFilter.mode = ColorBlindMode.Tritanomaly;
                print("Tritanomaly");

                break;
            case 7:
                colorBlindFilter.mode = ColorBlindMode.Achromatopsia;
                print("Achromatopsia");

                break;
            case 8:
                colorBlindFilter.mode = ColorBlindMode.Achromatomaly;
                print("Achromatomaly");

                break;
            default:
                print("nao pegou valor");
                break;
        }
        colorID = color;
        PlayerPrefs.SetInt("cor", colorID);
        print(PlayerPrefs.GetInt("cor", colorID));
    }

}
