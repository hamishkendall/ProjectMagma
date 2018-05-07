using UnityEngine;
using UnityEngine.UI;

class UIManager : MonoBehaviour {
   
    public PlayerDetails pDetails;
    public PauseMenuUI pauseMenu;
    public StatsUI statsMenu;
    public Image healthBar;

    //This method is run every frame. Can be taxing on some computers. Checks for button presses.
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

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (statsMenu.isOpen)
            {
                statsMenu.Close();
            }
            else
            {
                statsMenu.Open();
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {

            //THIS IS PLACEHOLDER IT WILL CALL A METHOD FROM GAME MANAGER.
            pDetails.TakeDmg(1);
            healthBar.fillAmount = pDetails.GetHp();
            Debug.Log(pDetails.curHp / pDetails.maxHp);
        }
    }
}
