using UnityEngine;

public class InventoryUI : MonoBehaviour {
    public Transform itemsParent;
    public GameObject inventoryUI;
    Inventory inventory;

    InventorySlot[] slots;
	
	void Start () {
        inventoryUI.SetActive(false); // Inventory is closed at the start
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}

	void Update () {
       
         //Opening and closing inventory with the key I
         if (Input.GetKeyDown(KeyCode.I))
         {
            Debug.Log("opennnnn");
            inventoryUI.SetActive(!inventoryUI.activeSelf);
         }
	} 

    void UpdateUI()
    {        
        //Updating inventory
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
