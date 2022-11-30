using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TextMeshProUGUI swordSettingText;
    public string swordSetting;
    public SwordMovement sword;

    public void Start()
    {
        if (PlayerPrefs.GetString("SwordSetting") == null || PlayerPrefs.GetString("SwordSetting") == "")
        {
            PlayerPrefs.SetString("SwordSetting", "Default");
        }

        swordSetting = PlayerPrefs.GetString("SwordSetting");
        swordSettingText.text = swordSetting;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void ChangeSwordSetting()
    {
        switch (swordSetting)
        {
            case "Default":
                PlayerPrefs.SetString("SwordSetting", "Classic");
                break;
            case "Classic":
                PlayerPrefs.SetString("SwordSetting", "Story");
                break;
            case "Story":
                PlayerPrefs.SetString("SwordSetting", "Default");
                break;
            default:
                PlayerPrefs.SetString("SwordSetting", "Default");
                break;
        }

        swordSetting = PlayerPrefs.GetString("SwordSetting");
        swordSettingText.text = swordSetting;

        if (sword != null)
        {
            sword.ChangeSwordSurf();
        }
    }
}
