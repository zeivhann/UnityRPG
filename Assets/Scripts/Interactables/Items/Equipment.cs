using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
[RequireComponent(typeof(HandleContextMenu))]
public class Equipment : Item {
    // Define attributes for a piece of equipment
    public EquipmentSlot equipSlot;

    // Mesh assigned to equipment for appearing on the player
    public SkinnedMeshRenderer mesh;

    public EquipmentMeshRegion[] coveredMeshRegions;

    public int armorModifier;
    public int damageModifier;

    // Notify when Context Menu has been changed
    public delegate string OnContextChanged(string choice);
    public OnContextChanged onContextChanged;


    public override void Use()
    {
        // Show context menu
        // If there is already a context menu open, delete the game object
        if (GameObject.Find(GameManager.CONTEXT_MENU_TITLE) != null)
        {
            Destroy(GameObject.Find(GameManager.CONTEXT_MENU_TITLE));
        }

        base.ShowMenu();
        
        base.Use();
    }

    public void MakeChoice(string choice)
    {
        if (choice.Equals("Equip"))
        {
            // Equip the item
            EquipmentManager.instance.Equip(this);

            // Remove it from the inventory
            RemoveFromInventory();
        }
        else if (choice.Equals("Drop"))
        {
            RemoveFromInventory();
        }
    }

}

// In the Unity editor, this will allow the assigning of the equipment in a drop down menu
public enum EquipmentSlot { Head, Neck, Chest, Legs, Waist, RightHand, LeftHand, Feet }
public enum EquipmentMeshRegion { Legs, Arms, Torso } // Corresponds to body blendshapes