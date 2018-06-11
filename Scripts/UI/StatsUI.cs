using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StatsUI : MonoBehaviour
{

    public PlayerDetails pDetails;
    private Text staText, strText, dexText, defText, unalloText;
    public GameObject statUI;
    public UIManager uiManager;

    //this method is run on the game start. Initializes the stat numbers.
    void Start () {

        staText = GameObject.Find("StaNumText").GetComponent<Text>();
        strText = GameObject.Find("StrNumText").GetComponent<Text>();
        dexText = GameObject.Find("DexNumText").GetComponent<Text>();
        defText = GameObject.Find("DefNumText").GetComponent<Text>();
        unalloText = GameObject.Find("UnallocatedNum").GetComponent<Text>();

        staText.text = Convert.ToString(pDetails.GetStatPoints(1));
        strText.text = Convert.ToString(pDetails.GetStatPoints(2));
        dexText.text = Convert.ToString(pDetails.GetStatPoints(3));
        defText.text = Convert.ToString(pDetails.GetStatPoints(4));

        unalloText.text = Convert.ToString(pDetails.GetUnallocatedPts());
    }

    //This method is called every button click on the StatUI. Gets the updated player stats.
    public void UpdatePlayerStats(int stat)
    {
        switch (stat)
        {
            case 1:
                staText.text = Convert.ToString(pDetails.GetStatPoints(stat));
                uiManager.UpdateHealthBar();
                break;

            case 2:
                strText.text = Convert.ToString(pDetails.GetStatPoints(stat));
                break;

            case 3:
                dexText.text = Convert.ToString(pDetails.GetStatPoints(stat));
                break;

            case 4:
                defText.text = Convert.ToString(pDetails.GetStatPoints(stat));
                break;
        }

        unalloText.text = Convert.ToString(pDetails.GetUnallocatedPts());
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
    }

    //This method is called every button click on the StatUI. Gets updated unallocated stat points.
    public void UpdateUnallocatedPts()
    {
        unalloText.text = Convert.ToString(pDetails.GetUnallocatedPts());
    }


}
