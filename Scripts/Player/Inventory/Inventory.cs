
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> items;
    public int space = 20;
    public AudioSource itemReceived;

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
    public OnitemChanged onItemChangedCallback;

    public void AddItem(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("no room");
            return;
        }
        items.Add(item);
        itemReceived.Play();

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
    

 
    
}
