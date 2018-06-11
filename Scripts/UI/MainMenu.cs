using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public SettingsMenu settingsMenu;
    public GameObject playButton;
    public GameObject closeButton;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Close()
    {
        Application.Quit();
    }

    public void Settings()
    {
        if (settingsMenu.isOpen)
        {
            settingsMenu.Close();
            playButton.SetActive(true);
            closeButton.SetActive(true);
        }
        else
        {
            settingsMenu.Open();
            playButton.SetActive(false);
            closeButton.SetActive(false);
        }
    }
}
