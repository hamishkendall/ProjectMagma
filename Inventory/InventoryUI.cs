using UnityEngine;

public class InventoryUI : MonoBehaviour {
    public Transform itemsParent;
    public GameObject inventoryUI;
    Inventory inventory;
    InventorySlot[] slots;
	
	void Start () {
        inventoryUI.SetActive(false); // This hides the inventory at the start
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI; // Call UpdateUI method when there is a change in inventory
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();//Finding all the slots under itemsParent
	}

	void Update () {
       
         //Opening and closing inventory with the key I
         if (Input.GetKeyDown(KeyCode.I))
         {           
            inventoryUI.SetActive(!inventoryUI.activeSelf);
         }
	} 

    void UpdateUI()
    {        
        //Updating inventory UI
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
