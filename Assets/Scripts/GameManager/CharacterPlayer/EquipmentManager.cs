using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton
    // Use a singleton to get a global instance of the equpiment manager
    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    // Holds the mesh for the player body so we can reference it
    public SkinnedMeshRenderer targetMesh;

    public Equipment[] defaultEquipment;
    Equipment[] currentEquipment; // Items that are currently equipped
    SkinnedMeshRenderer[] meshes; // Meshes of currently equipped items

    // Notify when it items have been equipped or unequipped
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    // Get the number of slots from the EquipmentSlot enum by grabbing the names and getting the length
    // Then but that nuber into the equipment array
    void Start()
    {
        this.inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        meshes = new SkinnedMeshRenderer[numSlots];

        EquipDefaultItems();
    }

    // Equip item
    public void Equip (Equipment newItem)
    {
        // Gets the index of the item in the list of Enums
        int slotIndex = (int) newItem.equipSlot;

        // Handles unequipping current item
        Equipment oldItem = Unequip(slotIndex);

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        // Set the blendshapes for the meshes on the player's equipped items
        this.SetEquipmentBlendShapes(newItem, 100);

        // Put the new item into the currentEquipment array
        currentEquipment[slotIndex] = newItem;

        // Add the new item mesh to the player
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;

        // Tell mesh how to deform to character body
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;

        // Add the new mesh to the current mesh array
        meshes[slotIndex] = newMesh;
    }

    // Set the blendshape for a piece of equipment so it forms properly to the body
    void SetEquipmentBlendShapes (Equipment item, int weight)
    {
        // Loop through each blendshape in the EquipmentMeshRegion enum that exists in the current coveredMeshRegions array
        foreach (EquipmentMeshRegion blendShape in item.coveredMeshRegions)
        {
            // casting blendShape to (int) returns the index of the enum
            targetMesh.SetBlendShapeWeight((int)blendShape, weight);
        }
    }

    // Unequip an item; returns the item that was unequipped
    public Equipment Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            // Delete the game object mesh off of the player
            if (meshes[slotIndex] != null)
            {
                Destroy(meshes[slotIndex].gameObject);
            }

            Equipment oldItem = currentEquipment[slotIndex];

            // set blendShapes to zero because mesh is removed from player
            this.SetEquipmentBlendShapes(oldItem, 0);

            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
            return oldItem;
        }
        return null;
    }

    public void UnequipAll ()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }

        // Equip player with default items (meshes)
        EquipDefaultItems();
    }

    // Equips starting items
    void EquipDefaultItems()
    {
        foreach (Equipment item in this.defaultEquipment)
        {
            Equip(item);
        }
    }

    void Update ()
    {
        // If the hotkey for unequipall is pressed, unequip all items
        if (Input.GetButtonDown("Unequip All"))  UnequipAll();
    }
}
