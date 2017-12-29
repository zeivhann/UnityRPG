using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for picking up an item
public class ItemPickUp : Interactable {
    // Holds information about item being interacted with
    public Item item;

    // Overrides Interact function in parent class
	public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picked up " + this.item.name);
        // Add to inventory

        // Remove from scene
        Destroy(this.gameObject);
    }
}
