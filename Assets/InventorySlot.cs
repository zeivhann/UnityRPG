using UnityEngine;
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

    // Use item
    public void UseItem ()
    {
        if (this.item != null)
        {
            this.item.Use();
        }
    }
}
