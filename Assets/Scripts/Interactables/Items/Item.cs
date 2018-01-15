using System.Collections;
using System.Collections.Generic;
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

    // Hold context menu, set in editor
    public ContextMenuOptions[] contextMenu;

    // Each item will have its own uses so this is virtual; to be overridden.
    public virtual void Use()
    {
        
    }

    // Create empty game object and attach the context menu to it and set its contents
    public virtual void ShowMenu ()
    {
        GameObject obj = new GameObject(GameManager.CONTEXT_MENU_TITLE);
        obj.AddComponent<DrawContextMenu>();
        DrawContextMenu menu = obj.GetComponent<DrawContextMenu>();
        menu.SetContextMenu(this);
    }


    // Remove current item from inventory instance
    public void RemoveFromInventory ()
    {
        Inventory.instance.Remove(this);
    }
}