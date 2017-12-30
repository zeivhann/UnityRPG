using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;

	void Start () {
		// Get inventory from singleton
        this.inventory = Inventory.instance;

        // onItemChangedCallback gets called whenever something has been added or removed from inventory
        inventory.onItemChangedCallback += UpdateUI;

        // Add all items in inventory to slots array
        // With a static amount of slots in the inventory, we only need to check this once.
        // It will need to be changed if we want to have dynamic slots
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}

    void Update ()
    {
        // If the player presses the inventory button, we want to do the inverse of whatever state the inventory is in (if it's open, we ant to close it, and vice versa)
        if (Input.GetButtonDown("Inventory"))
        {
            this.inventoryUI.SetActive(!this.inventoryUI.activeSelf);
        }
    }
	
    // Add or remove items to inventory by looping through each slot
    // If the item is in the array, add it to the inventory, otherwise empty it
	void UpdateUI ()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].EmptySlot();
            }
        }
	}
}
