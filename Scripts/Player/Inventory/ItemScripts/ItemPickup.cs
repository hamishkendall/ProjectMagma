
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    private bool isInRange;
    [SerializeField] KeyCode itemPickup = KeyCode.X;
    public Item item;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(itemPickup))
        {
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
