using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    private Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    private bool fullScreen;
    private Resolution currentRes;
    public bool isOpen;
    public GameObject settingsMenu;

    void Start()
    {
        fullScreen = true;
        resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == 60).ToArray();

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
                currentRes = resolutions[i];
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen(bool isFull)
    {
        Screen.SetResolution(currentRes.width, currentRes.height, isFull);
        fullScreen = isFull;
    }

    public void SetResolution(int resolutionIndex)
    {
        currentRes = resolutions[resolutionIndex];
        Screen.SetResolution(currentRes.width, currentRes.height, fullScreen);
    }

    public void Open()
    {
        settingsMenu.SetActive(true);
        Time.timeScale = 0f;
        isOpen = true;
    }

    public void Close()
    {
        settingsMenu.SetActive(false);
        Time.timeScale = 1f;
        isOpen = false;
    }
}
