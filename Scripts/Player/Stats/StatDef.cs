public class StatDef
{
    private int pointsAdded, pointCap;

    public StatDef()
    {
        this.pointsAdded = 0;
        this.pointCap = 100;
    }

    //Constructor for loading saved game
    public StatDef(int pointsAdded, int pointCap)
    {
        this.pointsAdded = 0;
        this.pointCap = pointCap;
    }

    //Adds stat point if not exceeding pointcap
    public void AddStat()
    {
        if (pointsAdded < pointCap)
        {
            ++pointsAdded;
        }
    }

    //Adds stat point if are points added
    public void RemoveStat()
    {
        if (pointsAdded > 0)
        {
            --pointsAdded;
        }
    }

    public int GetStatPoints()
    {
        return pointsAdded;
    }

    //Calculates the damage reduction for statpoints
    //1 point = 0.5% damage reduction
    //Returns a %
    public double GetDamageReduction()
    {
        double damageReduction = (double)pointsAdded;

        if (damageReduction == 0)
        {
            return 0;
        }

        damageReduction *= 0.5;

        return (damageReduction/100);
    }
}
