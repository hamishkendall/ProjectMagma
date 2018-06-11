using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {
   
    public PlayerDetails pDetails;
    public PauseMenuUI pauseMenu;
    public StatsUI statsMenu;
    public Image healthBar;
    public Image expBar;
    public TextMeshProUGUI level;
    public Text playerHp;

    //This method is run every frame. Can be taxing on some computers. Checks for button presses.

    private void Start()
    {
        level.text = "" + pDetails.curLv;
        playerHp.text = "HP: " + pDetails.GetHp()*100 + "%" + " - " + pDetails.maxHp;
    }

    public void UpdateHealthBar()
    {
        healthBar.fillAmount = pDetails.GetHp();
        playerHp.text = "HP: " + pDetails.GetHp() * 100 + "%" + " - " + pDetails.maxHp;
    }

    public void UpdateExp()
    {
        expBar.fillAmount = pDetails.GetExp();
    }

    public void UpdateLevel()
    {
        level.text = "" + pDetails.curLv;
        statsMenu.UpdateUnallocatedPts();
        UpdateHealthBar();
    }

    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.isPaused)
            {
                pauseMenu.Resume();
            }
            else
            {
                pauseMenu.Pause();
            }
        }
    }
}
