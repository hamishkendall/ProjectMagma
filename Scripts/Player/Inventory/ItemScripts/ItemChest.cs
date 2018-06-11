using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChest : MonoBehaviour {
    [SerializeField] Item[] item;
    [SerializeField] KeyCode itemPickupKeyCode = KeyCode.E;
    public bool isInRange;
    public bool isEmpty;

    private void Start()
    {
        if (item == null)
        {
            isEmpty = true;
        }
        else
        {
            isEmpty = false;
        }
    }

    // Update is called once per frame
    void Update () {
        //picking up the item when player is near the chest and press the itemPickupCode E
        if (isInRange && Input.GetKeyDown(itemPickupKeyCode))
        {   
            //make sure player can only loot the chest once 
            if (!isEmpty)
            {
                for(int i = 0; i < item.Length; i++)
                {
                    Item itemGiven = item[i];
                    Inventory.instance.AddItem(itemGiven);
                }
                isEmpty = true;
            }
        }
	}
    //method that send boolean wether playter is near the chest to loot
    private void OnTriggerEnter2D(Collider2D other)
    {
        isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInRange = false;
    }
}
