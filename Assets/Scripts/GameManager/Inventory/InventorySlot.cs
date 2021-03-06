﻿using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    // Member variables hold information for icon in inventory and item information
    public Image icon;

    Item item;

    public Button removeButton;

    // Instantiate item in inventory
    public void AddItem (Item newItem)
    {
        this.item = newItem;

        this.icon.sprite = item.icon;
        this.icon.enabled = true;
        this.removeButton.interactable = true;

        /*
        // If item is Equipment, add Equipment Context Menu
        if (newItem.GetType() == typeof(Equipment))
        {
            this.equipmentMenu = GetComponent<EquipmentContextMenu>();
        }
        */

        // TODO: Add types for consumable and interactable
    }

    // Remove item from inventory slot
    public void EmptySlot ()
    {
        this.item = null;

        this.icon.sprite = null;
        this.icon.enabled = false;
        this.removeButton.interactable = false;
    }

    // When remove button is clicked in inventory
    public void OnRemoveButton ()
    {
        Inventory.instance.Remove(item);
    }

    // Use item or bring up inventory context menu
    public void UseItem ()
    {
        if (this.item != null)
        {
            // Logic for using item
            this.item.Use();
        }
    }
}
