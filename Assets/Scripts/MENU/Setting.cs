using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Setting : MonoBehaviour 
{
    private AudioSource audioSrc;
    public TMP_Dropdown resolutionDropDown;
    public TMP_Dropdown qualityDropDown;
    private float currentVolumn =0.1f;

    Resolution[] resolutions;
    

    public void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "HZ";
            options.Add(option);
            if (resolutions[i].width ==  Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height ) 
            {
                currentResolutionIndex = i;
            }

        }
        resolutionDropDown.AddOptions( options );
        resolutionDropDown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);

       
    }

    public void Update()
    {
        audioSrc.volume = currentVolumn;
    }
    public void SetVolumn(float volumne)
    {
        
        currentVolumn = volumne;
    }


    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

    }
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropDown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropDown.value);
        PlayerPrefs.SetInt("FullScreenPreference", System.Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumePreference", currentVolumn);
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if(PlayerPrefs.HasKey("QualitySettingPreference"))
            qualityDropDown.value = PlayerPrefs.GetInt("QualitySettingpreference");
        else
            qualityDropDown.value = 3;

        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropDown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else resolutionDropDown.value = currentResolutionIndex;

        if(PlayerPrefs.HasKey("FullScreenPreference"))
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullScreenPreference"));
        else Screen.fullScreen = true;
    }

}
