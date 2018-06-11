using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour{

    public bool isPaused = false;
    public GameObject PauseMenu;
    public EnemyAI aiMobs;

    //this method is run on game start.
    private void Start()
    {
        PauseMenu.SetActive(false);
    }

    //This resumes to game: Timescale 0 is pause, 1 is normal time. any value in between is slowmotion.
    public void Resume()
    {
        PauseMenu.SetActive(false);
        aiMobs.resumeAi();
        Time.timeScale = 1f;
        isPaused = false;
    }

    //This pauses the game: Timescale 0 is pause, 1 is normal time. any value in between is slowmotion.
    public void Pause()
    {
        PauseMenu.SetActive(true);
        aiMobs.pauseAi();
        Time.timeScale = 0f;
        isPaused = true;
    }

    //This loads the main menu when button pressed.
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    //This closes the application when button pressed.
    public void QuitGame()
    {
        Application.Quit();
    }
}
