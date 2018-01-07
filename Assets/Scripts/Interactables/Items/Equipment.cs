﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {
    // Define attributes for a piece of equipment
    public EquipmentSlot equipSlot;

    // Mesh assigned to equipment for appearing on the player
    public SkinnedMeshRenderer mesh;

    public EquipmentMeshRegion[] coveredMeshRegions;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();

        // Equip the item
        EquipmentManager.instance.Equip(this);
        
        // Remove it from the inventory
        RemoveFromInventory();
    }

}

// In the Unity editor, this will allow the assigning of the equipment in a drop down menu
public enum EquipmentSlot { Head, Neck, Chest, Legs, Waist, RightHand, LeftHand, Feet}
public enum EquipmentMeshRegion { Legs, Arms, Torso }; // Corresponds to body blendshapes