public class StatSta
{
    private int pointsAdded, pointCap;

    public StatSta()
    {
        this.pointsAdded = 0;
        this.pointCap = 100;
    }

    //Constructor for loading saved game
    public StatSta(int pointsAdded, int pointCap)
    {
        this.pointsAdded = 0;
        this.pointCap = pointCap;
    }

    //Adds stat point if not exceeding pointcap
    public int AddStat()
    {
        int statVal = pointsAdded;

        if (pointsAdded < pointCap)
        {
            ++pointsAdded;
            ++statVal;
        }

        return statVal;
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

    public int GetBonusHp()
    {
        return pointsAdded*2;
    }
}
