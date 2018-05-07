
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> items;
    public int space = 20; // Space of the inventory

    #region Singleton 

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one stance of inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnitemChanged();
    public OnitemChanged onItemChangedCallback; // trigger this when theres a change in inventory, needed for updating inventory UI


    //Method for adding item into inventory
    public void AddItem(Item item)
    {
        // Checking if the inventory space is not full
        if (items.Count >= space)
        {
            Debug.Log("no room");
            return;
        }
        items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    // Method for removing item in inventory but currently not using yet
    public void RemoveItem(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
    

 
    
}
