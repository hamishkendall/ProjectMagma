using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{

    public Image icon;

    Item item;
    //Add items into slots
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }
    //removing items from slots
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

}
