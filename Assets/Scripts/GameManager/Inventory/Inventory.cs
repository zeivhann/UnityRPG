using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton
    // Use this to find the instance of Inventory that we want to use and keep constant
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory Found.");
            return;
        }

        instance = this;
    }

    #endregion

    // Delegate to watch when the inventory has been added to or removed from
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    // List that holds items that are in the inventory
    public List<Item> items = new List<Item>();

    // Add items to inventory
    public bool Add (Item item)
    {
        if (!item.isStartingItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Inventory is full.");
                return false;
            }
            
            // Add item to inventory
            items.Add(item);

            // Call the delegate to notify that the inventory has been changed.
            if (onItemChangedCallback != null) onItemChangedCallback.Invoke();
        }
        return true;
    }

    // Remove item from inventory
    public void Remove (Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null) onItemChangedCallback.Invoke();
    }
}
