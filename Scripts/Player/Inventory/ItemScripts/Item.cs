
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite icon;
    public int Stamina;
    public int Strength;
    public int Dex;
    public int Defence;
    public EquipmentSlot equipSlot;
    public int itemDamage;

    public virtual void Use()
    {
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }

    // Remove item from inventory when equip
    public void RemoveFromInventory()
    {
        Inventory.instance.RemoveItem(this);
    }



}
public enum EquipmentSlot { Weapon, Helmet, Armor, Jewellery, Consumable }
