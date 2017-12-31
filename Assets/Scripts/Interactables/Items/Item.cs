
using UnityEngine;

// Base class for items in game
// Inherits from unity ScriptableObject
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {
    // Items are going to have different types of attributes which will be set in this class.

    // ScriptableObject already has a name, so we override the old one
    new public string name = "<New Name>";

    // Set an icon for inventory
    public Sprite icon = null;

    // sets if item is a starting item
    public bool isStartingItem = false;


    // Each item will have its own uses so this is virtual; to be overridden.
    public virtual void Use()
    {
        // Use item
        // We want to open context menu when item is clicked in the inventory
        Debug.Log("Using " + this.name);
        Debug.Log("Open context menu for inventory");
    }

    // Remove current item from inventory instance
    public void RemoveFromInventory ()
    {
        Inventory.instance.Remove(this);
    }
}
