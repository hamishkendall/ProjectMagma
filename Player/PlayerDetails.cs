using System;
using UnityEngine;

public class PlayerDetails : MonoBehaviour
{
    public float maxHp, curHp;
    public int curLv, curExp;

    public bool playerAlive;

    private PlayerStats pStats;


    //Creates a new Character
    public PlayerDetails()
    {
        maxHp = 10;
        curHp = 10;
        curLv = 1;
        curExp = 0;
        playerAlive = true;

        pStats = new PlayerStats();
    }

    //Constructor for Load game
    public PlayerDetails(int maxHp, int curHp, int curLv, int curExp, PlayerStats pStats)
    {

    }

    public void TakeDmg(int dmg)
    {
        //Applys defence damage reduction
        int trueDamage = pStats.ApplyDamageReduction(dmg);
        Debug.Log("Damage: "+trueDamage);

        try
        {
            //Checks if attack will kill character
            if((curHp - trueDamage) <= 0)
            {
                Debug.Log("Fatal hit to player");
                throw new ArgumentOutOfRangeException();
            }

            curHp -= trueDamage;
            Debug.Log("Player hit for "+trueDamage);
        }
        catch (ArgumentOutOfRangeException)
        {
            //Player is dead
            Debug.Log("Player Died");
            playerAlive = false;
        }
    }

    //Heals the character
    public void TakeHeal(int heal)
    {
        if ((curHp + heal) >= maxHp)
        {
            curHp = maxHp;
        }
        else
        {
            curHp += heal;
        }
    }

    //Adds Statpoint to stat - 1Sta - 2Str - 3Dex - 4Def
    public void AddStat(int stat) //StatType stat
    {
        switch (stat)
        {
            case 1: pStats.AddStat(StatType.sta);
                break;

            case 2: pStats.AddStat(StatType.str);
                break;

            case 3: pStats.AddStat(StatType.dex);
                break;

            case 4: pStats.AddStat(StatType.def);
                break;
        }
        
    }

    //Removes Statpoints - 1Sta - 2Str - 3Dex - 4Def
    public void RemoveStat(int stat)
    {
        switch (stat)
        {
            case 1:
                pStats.RemoveStat(StatType.sta);
                break;

            case 2:
                pStats.RemoveStat(StatType.str);
                break;

            case 3:
                pStats.RemoveStat(StatType.dex);
                break;

            case 4:
                pStats.RemoveStat(StatType.def);
                break;
        }
    }

    //Returns stat value as a String for updating UI
    public String GetStatPoints(int stat)
    {
        String pts = "";

        switch (stat)
        {
            case 1: pts = Convert.ToString(pStats.GetStatPoints(StatType.sta));
                break;

            case 2: pts = Convert.ToString(pStats.GetStatPoints(StatType.str));
                break;

            case 3: pts = Convert.ToString(pStats.GetStatPoints(StatType.dex));
                break;

            case 4: pts = Convert.ToString(pStats.GetStatPoints(StatType.def));
                break;
        }
        return pts;
    }

    public String GetUnallocatedPts()
    {
        return Convert.ToString(pStats.unallocatedPts);
    }

    //Adds exp value and calculates level;
    public void AddExp(int exp)
    {
        double remExp = (double)exp;

        while(remExp > 0)
        {
            if(remExp > ExpForLevel())
            {
                remExp -= ExpForLevel();
                ++curLv;
            }
            else
            {
                curExp = (int)Math.Round(remExp);
                remExp = 0;
            }
        }
    }

    //Calculates total exp required to level
    private double ExpForLevel()
    {
        return Math.Pow(curLv,3);
    }

    //Updates the hp 
    private void UpdateHp()
    {
        float bonusHp = pStats.sta.GetBonusHp();
            
        //Adds bonus hp  without healing player back to full
        if((maxHp - bonusHp) != 10)
        {
            //Hp not full
            curHp += bonusHp;
            maxHp += bonusHp;
        }
        else
        {
            //Hp full
            maxHp += bonusHp;
            curHp = maxHp;
        }
    }

    //Returns HP as a % (0.99)
    public float GetHp()
    {
        return (curHp / maxHp);
    }

}
