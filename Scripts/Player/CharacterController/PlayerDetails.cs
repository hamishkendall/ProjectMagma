using System;
using UnityEngine;

public class PlayerDetails : MonoBehaviour
{
    public float maxHp, curHp;
    public int curLv, curExp;
    public bool playerAlive;
    private PlayerStats pStats;
    public Item itemArmor, itemHelmet, itemJewl, itemWep;
    public GameManager gm;
    public AnimationHandler ani;

    //Creates a new Character
    public PlayerDetails()
    {
        maxHp = 100;
        curHp = 100;
        curLv = 1;
        curExp = 0;
        playerAlive = true;

        pStats = new PlayerStats();

    }

    //Constructor for Load game
    public PlayerDetails(int maxHp, int curHp, int curLv, int curExp, bool playerAlive, PlayerStats pStats)
    {
        this.maxHp = maxHp;
        this.curHp = curHp;
        this.curLv = curLv;
        this.curExp = curExp;
        this.playerAlive = playerAlive;

        this.pStats = pStats;
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

        if(gm != null)
            UpdateHpBar();
    }

    //Adds Statpoint to stat - 1Sta - 2Str - 3Dex - 4Def
    public void AddStat(int stat) //StatType stat
    {
        if (GetUnallocatedPts() > 0)
            switch (stat)
            {
                case 1: pStats.AddStat(StatType.sta);
                    UpdateAddedHp();
                    break;

                case 2: pStats.AddStat(StatType.str);
                    break;

                case 3: pStats.AddStat(StatType.dex);
                    break;

                case 4: pStats.AddStat(StatType.def);
                    break;
            }
        
    }

    private void UpdateAddedHp()
    {
        maxHp += pStats.GetHpBonus();
        curHp += pStats.GetHpBonus();
    }

    private void UpdateRemovedHp()
    {
        maxHp -= pStats.GetHpBonus();
        curHp -= pStats.GetHpBonus();
    }

    //Removes Statpoints - 1Sta - 2Str - 3Dex - 4Def
    public void RemoveStat(int stat)
    {
        switch (stat)
        {
            case 1:
                UpdateRemovedHp();
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
    public int GetStatPoints(int stat)
    {
        int pts = 0;

        switch (stat)
        {
            case 1: pts = pStats.GetStatPoints(StatType.sta);
                break;

            case 2: pts = pStats.GetStatPoints(StatType.str);
                break;

            case 3: pts = pStats.GetStatPoints(StatType.dex);
                break;

            case 4: pts = pStats.GetStatPoints(StatType.def);
                break;
        }
        return pts;
    }

    public int GetUnallocatedPts()
    {
        return pStats.unallocatedPts;
    }

    //Adds exp value and calculates level;
    public void AddExp(int exp)
    {
        double remExp = (double)exp;

        while(remExp > 0)
        {
            if(remExp >= ExpForLevel())
            {
                remExp -= ExpForLevel();
                LevelUp();
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
        int exp = 0;
        switch (curLv)
        {
            case 1: exp = 100;
                break;

            case 2: exp = 200;
                break;

            case 3: exp = 500;
                break;

            case 4: exp = 1000;
                break;

            case 5: exp = 2000;
                break;

            default: exp = 2500;
                break;
        }

        return exp;
        //Creating switch statement for exp
        //return Math.Pow(curLv,3);
    }

    //Levelup the char and adds 20 statpts
    private void LevelUp()
    {
        ++curLv;
        pStats.addUnallocatedPoints(4);
        curHp = maxHp;
    }

    //Returns HP as a % (0.99)
    public float GetHp()
    {
        return (curHp / maxHp);
    }

    public void ChangeArmor(Item item)
    {
        itemArmor = item;
    }

    public void ChangeHelmet(Item item)
    {
        itemHelmet = item;
    }

    public void ChangeJewellery(Item item)
    {
        itemJewl = item;
    }

    public void ChangeWep(Item item)
    {
        itemWep = item;
    }

    public float GetExp()
    {
        return (curExp / (float)ExpForLevel());
    }

    public void RespawnPlayer()
    {
        curHp = maxHp;
        playerAlive = true;
        ani.Idle();
    }

    public int GetPlayerDamage()
    {
        int pDmg = GetEquipItemStr();
        pDmg += pStats.GetStrBonus();
        return pDmg;
    }

    public void TakeDmg(int dmg)
    {
        try
        {
            int dodgeChance = GetEquipItemDex() + pStats.dex.getDodgeChance();
            System.Random rng = new System.Random();

            if (dodgeChance <= rng.Next(1, 100)){
                throw new DivideByZeroException();
            }

            //Applys defence damage reduction
            int trueDamage = pStats.ApplyDamageReduction(dmg, GetEquipItemDef());

            //Checks if attack will kill character
            if ((curHp - trueDamage) <= 0)
            {
                Debug.Log("Fatal hit to player");
                throw new ArgumentOutOfRangeException();
            }

            curHp -= trueDamage;
        }
        catch (ArgumentOutOfRangeException)
        {
            //Player is dead
            Debug.Log("Player Died");
            playerAlive = false;

            ani.Dead();
            //****************
            //ASK FOR RESPAWN VIA UI
            //****************
        }
        catch (DivideByZeroException){
            //Character Dodged       
        }
    }

    private void UpdateHpBar()
    {
        gm.uiMan.UpdateHealthBar();
    }

    private int GetEquipItemStr()
    {
        int str = 0;
        if(itemArmor != null)
        {
            str += itemArmor.Strength;
            str += itemArmor.itemDamage;
        } 
        if (itemHelmet != null)
        {
            str += itemHelmet.Strength;
            str += itemHelmet.itemDamage;
        }
        if (itemJewl != null)
        {
            str += itemJewl.Strength;
            str += itemJewl.itemDamage;
        }            
        if (itemWep != null)
        {
            str += itemWep.Strength;
            str += itemWep.itemDamage;
        }            
        return str;
    }

    private int GetEquipItemSta()
    {
        int sta = 0;
        if (itemArmor != null)
            sta += itemArmor.Stamina;
        if (itemHelmet != null)
            sta += itemHelmet.Stamina;
        if (itemJewl != null)
            sta += itemJewl.Stamina;
        if (itemWep != null)
            sta += itemWep.Stamina;
        return sta;
    }

    private int GetEquipItemDex()
    {
        int dex = 0;
        if (itemArmor != null)
            dex += itemArmor.Dex;
        if (itemHelmet != null)
            dex += itemHelmet.Dex;
        if (itemJewl != null)
            dex += itemJewl.Dex;
        if (itemWep != null)
            dex += itemWep.Dex;
        return dex;
    }

    private double GetEquipItemDef()
    {
        double def = 0;
        if (itemArmor != null)
            def += itemArmor.Defence;
        if (itemHelmet != null)
            def += itemHelmet.Defence;
        if (itemJewl != null)
            def += itemJewl.Defence;
        if (itemWep != null)
            def += itemWep.Defence;
        return def;
    }
}