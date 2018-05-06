
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    private bool isInRange;
    [SerializeField] KeyCode itemPickup = KeyCode.X;// Key for picking up item
    public Item item;
    public Inventory inventory;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(itemPickup))
        {            
            Inventory.instance.AddItem(item);//Adding item to inventory
            Destroy(gameObject);//Destroying the object after pick up
        }
    }
    //Checking if the object is in range with the player
    private void OnTriggerEnter2D(Collider2D other)
    {
       isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       isInRange = false;
    }

    


}
