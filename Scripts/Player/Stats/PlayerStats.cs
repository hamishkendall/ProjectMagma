
/*
 * Author: Hamish
 * Date: 11/05/18
 * 
 * This class holds the required information to allow players to add and remove stats
 * It also calculates stat based information such as damage reduction and player damage
 */


using System;
using UnityEngine;

    public class PlayerStats
    {
        public StatSta sta;
        public StatStr str;
        public StatDex dex;
        public StatDef def;

        public int unallocatedPts;
        
        /*
         * Constructor for a new game
         */
        public PlayerStats()
        {
            unallocatedPts = 10;

            sta = new StatSta();
            str = new StatStr();
            dex = new StatDex();
            def = new StatDef();
        }

        /*
         * Overriden onstructor for loading saved game
         * @Param int number of unallocated points
         * @Param StatSta - holds the details for the stamina player stat
         * @Param StatStr -  holds the details for the strength player stat
         * @Param StatDex -  holds the details for the dexterity player stat
         * @Param StatDef -  holds the details for the defensive player stat
         */
        public PlayerStats(int unallocatedPts, StatSta sta, StatStr str, StatDex dex, StatDef def)
        {
            this.unallocatedPts = unallocatedPts;

            this.sta = sta;
            this.str = str;
            this.dex = dex;
            this.def = def;
        }


        /*
         * Adds a statpoint if there any unallocated points
         * @Param StatType - The stat type the player wants to increase
         */ 
        public void AddStat(StatType stat)
        {
            switch (stat)
            {
                case StatType.sta:  if (unallocatedPts > 0) { sta.AddStat(); --unallocatedPts; } 
                break;

                case StatType.str:  if (unallocatedPts > 0) { str.AddStat(); --unallocatedPts; } 
                break;

                case StatType.dex:  if (unallocatedPts > 0) { dex.AddStat(); --unallocatedPts; } 
                break;

                case StatType.def:  if (unallocatedPts > 0) { def.AddStat(); --unallocatedPts; } 
                break;
            }
        }


        /*
        * Removes a stat if the requested stat has any statpoints invested
        * @Param StatType - The stat type the player wants to decrease
        */
        public void RemoveStat(StatType stat)
        {
            switch (stat)
            {
                case StatType.sta:  if(GetStatPoints(StatType.sta) > 0) { sta.RemoveStat(); ++unallocatedPts; }
                    break;

                case StatType.str:  if(GetStatPoints(StatType.str) > 0) { str.RemoveStat(); ++unallocatedPts; }
                    break;

                case StatType.dex:  if(GetStatPoints(StatType.dex) > 0) { dex.RemoveStat(); ++unallocatedPts; }
                    break;

                case StatType.def:  if(GetStatPoints(StatType.def) > 0) { def.RemoveStat(); ++unallocatedPts; }
                    break;
            }
        }


        /*
         * Gets the number of invested stat points in a selected stat
         * @Param StatType - The Stat Type of requested stat 
         * @Return int - Returns the value of statpoints invested
         */ 
        public int GetStatPoints(StatType stat)
        {
            int points = 0;

            switch (stat)
            {
                case StatType.sta:  points = sta.GetStatPoints();
                    break;

                case StatType.str:  points = str.GetStatPoints();
                break;

                case StatType.dex:  points = dex.GetStatPoints();
                break;

                case StatType.def:  points = def.GetStatPoints();
                break;
            }

            return points;
        }

        /*
         * Applies the damage reduction from the defensive stat
         * @Param int - The damage taken before the defensive reduction is applied
         * @Return int - The actual damage the player takes after the damage reduction is applied 
         */ 
        public int ApplyDamageReduction(int dmg, double itemDef)
        {
            double dmgReduction = (def.GetDamageReduction() + ((itemDef/100)/2));

            //Converts damage hit to double, applys the damage reduction to the 
            double trueDamage = (Double)dmg - (dmgReduction * (Double)dmg);

            //Converts double to int (removes all decimal points)
            int finalDamage = Convert.ToInt32(trueDamage);

            return finalDamage;
        }

        public void addUnallocatedPoints(int pts)
        {
            unallocatedPts += pts;
        }

        public int ApplyDamageMultiplyer(int dmg)
        {
            return dmg*(str.GetStatPoints()/50);
        }

        public int GetHpBonus()
        {
            return sta.GetBonusHp();
        }

        public int GetStrBonus()
        {
            return str.GetBonusDmg();
        }
    }
