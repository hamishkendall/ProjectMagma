
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    private bool isInRange;
    [SerializeField] KeyCode itemPickup = KeyCode.X; // key press for picking up items.
    public Item item;
    public Inventory inventory;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(itemPickup))
        {
            Debug.Log("Picking up" + item.ItemName);
            Inventory.instance.AddItem(item);//add item to inventory UI
            Destroy(gameObject);//delets object in physical game world.
        }
    }


    //checkings if object is in range of player.
    private void OnTriggerEnter2D(Collider2D other)
    {
       isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       isInRange = false;
    }

    


}
