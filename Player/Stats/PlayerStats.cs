using System;
using UnityEngine;

    public class PlayerStats
    {
        public StatSta sta;
        public StatStr str;
        public StatDex dex;
        public StatDef def;

        public int unallocatedPts;
        
        //Contructor for new game
        public PlayerStats()
        {
            unallocatedPts = 10;

            sta = new StatSta();
            str = new StatStr();
            dex = new StatDex();
            def = new StatDef();
        }

        //Recreates CharStats from load file
        public PlayerStats(int unallocatedPts, StatSta sta, StatStr str, StatDex dex, StatDef def)
        {
            this.unallocatedPts = unallocatedPts;

            this.sta = sta;
            this.str = str;
            this.dex = dex;
            this.def = def;
        }


        //Adds stats if there are unallocatedPts
        public void AddStat(StatType stat)
        {
            switch (stat)
            {
                case StatType.sta:  if (unallocatedPts != 0) { sta.AddStat(); --unallocatedPts; } 
                    break;

                case StatType.str:  if (unallocatedPts != 0) { str.AddStat(); --unallocatedPts; } 
                break;

                case StatType.dex:  if (unallocatedPts != 0) { dex.AddStat(); --unallocatedPts; } 
                break;

                case StatType.def:  if (unallocatedPts != 0) { def.AddStat(); --unallocatedPts; } 
                break;
            }
        }


        //Removes stat from player if there are stats to remove
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


        public int ApplyDamageReduction(int dmg)
        {
            //Converts damage hit to double, applys the damage reduction to the 
            double trueDamage = ((1d - def.GetDamageReduction()) * (Double)dmg);

            //Rounds the double to whole number and converts back into int
            int finalDamage = Convert.ToInt32(trueDamage);

            return finalDamage;
        }

    }
