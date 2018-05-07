using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

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
        SceneManager.LoadScene("SettingsMenu");
    }

}
