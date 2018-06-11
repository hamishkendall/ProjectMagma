using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton   

    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public Item[] currentEquipment;
    Inventory inventory;
    EquipmentUI equipmentUI;
    public PlayerDetails pDets;

    //May use in the future
    public delegate void OnEquipmentChanged(Item newItem);
    public OnEquipmentChanged onEquipmentChanged;


    void Start()
    {
        inventory = Inventory.instance;
        equipmentUI = EquipmentUI.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Item[numSlots];
    }

    public void Equip(Item newItem)
    {
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem);
        }

        int slotIndex = (int)newItem.equipSlot;

        Item oldItem = null;
        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);
        }

        currentEquipment[slotIndex] = newItem;

        equipmentUI.UpdateUI(newItem, slotIndex);

        switch (newItem.equipSlot)
        {
            case EquipmentSlot.Armor: pDets.ChangeArmor(newItem);
                break;

            case EquipmentSlot.Consumable:  pDets.TakeHeal(200);
                break;

            case EquipmentSlot.Helmet:  pDets.ChangeHelmet(newItem);
                break;

            case EquipmentSlot.Jewellery:   pDets.ChangeJewellery(newItem);
                break;

            case EquipmentSlot.Weapon:  pDets.ChangeWep(newItem);
                break;
        }        
    }

}
