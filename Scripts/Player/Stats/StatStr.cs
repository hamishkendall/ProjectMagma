public class StatStr
{
    private int pointsAdded, pointCap;

    public StatStr()
    {
        this.pointsAdded = 0;
        this.pointCap = 100;
    }

    //Constructor for loading saved game
    public StatStr(int pointsAdded, int pointCap)
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

    public int GetBonusDmg()
    {
        return pointsAdded * 2;
    }
}
