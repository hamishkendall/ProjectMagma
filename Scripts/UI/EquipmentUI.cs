using UnityEngine;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour
{

    public Image icon;
    public Item item;
    public Transform itemsParent;
    public GameObject equipmentUI;
    private bool isOpen;
    EquipSlot[] slots;

    #region Singleton   

    public static EquipmentUI instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    void Start()
    {

        isOpen = false;
        equipmentUI.SetActive(false);
        slots = itemsParent.GetComponentsInChildren<EquipSlot>();
        //equipment.onEquipmentChanged += Update;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOpen)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    public void Open()
    {
        equipmentUI.SetActive(true);
        isOpen = true;

    }

    public void Close()
    {
        equipmentUI.SetActive(false);
        isOpen = false;

    }

    public void UpdateUI(Item newItem, int slotIndex)
    {

        if (0 == slotIndex)
        {
            slots[0].AddItem(newItem);
        }

        if (1 == slotIndex)
        {
            slots[1].AddItem(newItem);
        }

        if (2 == slotIndex)
        {
            slots[2].AddItem(newItem);
        }

        if (3 == slotIndex)
        {
            slots[3].AddItem(newItem);
        }

    }






}
