using UnityEngine.UI;
using UnityEngine;
using System.Text;

public class ItemTooltip : MonoBehaviour
{
    [SerializeField] Text ItemNameText;
    [SerializeField] Text ItemSlotText;
    [SerializeField] Text ItemStatsText;

    private StringBuilder sb = new StringBuilder();

    public void ShowTooltip(Item item)
    {
        if (item != null && item.equipSlot != EquipmentSlot.Consumable)
        {
            ItemNameText.text = item.ItemName;
            ItemSlotText.text = item.equipSlot.ToString();
            ItemStatsText.text = "Damage: " + item.itemDamage;
            ItemStatsText.text += "\nStamina: " + item.Stamina;
            ItemStatsText.text += "\nStrength: " + item.Strength;
            ItemStatsText.text += "\nDexterity: " + item.Dex;
            ItemStatsText.text += "\nDefence: " + item.Defence;
            /*
            AddStat(item.itemDamage, "Damage");
            AddStat(item.Stamina, "Stamina");
            AddStat(item.Strength, "Strength");
            AddStat(item.Dex, "Dex");
            AddStat(item.Defence, "Defence");

            sb.Length = 0;

            ItemStatsText.text = sb.ToString(); 
           */
            gameObject.SetActive(true);
        }
        else if(item != null && item.equipSlot == EquipmentSlot.Consumable)
        {
            //Addeded for Health pot
            ItemNameText.text = item.ItemName;
            ItemSlotText.text = item.equipSlot.ToString();
            ItemStatsText.text = "Item heals 200 HP";
            ItemStatsText.text += "\nThis item will";
            ItemStatsText.text += "\ndissapper on use";
            ItemStatsText.text += "\nThis item is a";
            ItemStatsText.text += "\none time use";

            gameObject.SetActive(true);
        }
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public void AddStat(float value, string statName)
    {
        if (value != 0)
        {
            if (sb.Length > 0)
                sb.AppendLine();
            if (value > 0)
                sb.Append("+");
            sb.Append(value);
            sb.Append(" ");
            sb.Append(statName);
        }
    }

}
