using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    //This the blueprint of the item. Currently only 2 variables to define an Item will add more later.
    public string ItemName;
    public Sprite icon;
    //int strength
    //int dex
    //int stamina
    //int defence 
}
