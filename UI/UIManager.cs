using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

class UIManager : MonoBehaviour {


    public PlayerDetails gameStats;
    public static bool isPaused = false;
    public static bool isOpen = false;
    public GameObject PauseMenuUI;
    public GameObject InventoryUI;
    public Image healthBar;
    public Text staText, strText, dexText, defText;

	void Start ()
    {
        staText.text = "0";
        strText.text = "0";
        dexText.text = "0";
        defText.text = "0";
	}
	
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.T))
        {
            gameStats.TakeDmg(1);
            healthBar.fillAmount = gameStats.GetHp();
            Debug.Log(gameStats.curHp / gameStats.maxHp);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOpen)
            {
                CloseInventory();
            }
            else
            {
                OpenInventory();
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void UpdatePlayerStats(int stat)
    {
        switch (stat)
        {
            case 1:
                staText.text = gameStats.GetStatPoints(stat);
                break;

            case 2:
                strText.text = gameStats.GetStatPoints(stat);
                break;

            case 3:
                dexText.text = gameStats.GetStatPoints(stat);
                break;

            case 4:
                defText.text = gameStats.GetStatPoints(stat);
                break;
        }
    }

    public void CloseInventory()
    {
        InventoryUI.SetActive(false);
        Time.timeScale = 1f;
        isOpen = false;
    }

    public void OpenInventory()
    {
        InventoryUI.SetActive(true);
        Time.timeScale = 0f;
        isOpen = true;
    }


    //This resumes to game: Timescale 0 is pause, 1 is normal time. any value in between is slowmotion.
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    //This pauses the game: Timescale 0 is pause, 1 is normal time. any value in between is slowmotion.
    void Pause()
    {
        PauseMenuUI.SetActive(true);
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
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
