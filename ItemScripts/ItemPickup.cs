
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    private bool isInRange;
    [SerializeField] KeyCode itemPickup = KeyCode.X;
    public Item item;
    public Inventory inventory;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(itemPickup))
        {
            Debug.Log("Picking up" + item.ItemName);
            Inventory.instance.AddItem(item);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       isInRange = false;
    }

    


}
