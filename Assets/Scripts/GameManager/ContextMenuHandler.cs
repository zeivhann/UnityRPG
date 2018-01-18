using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This class handles all context menus in the game
[CreateAssetMenu(fileName = "New Context Menu", menuName = "Context Menu")]
public class ContextMenuHandler : ScriptableObject {
    // Hold name and description of the object
    public new string name;
    public string description;

    public ContextMenuOptions[] options;

    // Show context menu
    public virtual void ShowMenu()
    {
        Debug.Log("Show context menu for " + this.name);
    }
}

// Enums for different types of menus

// All Options
public enum ContextMenuOptions { Equip, Use, Drop, Talk, Inspect, Open, Close }

/*
// Subsets of ContextMenuOptions for quicker access
public enum EquipmentContenxtMenu { ContextMenuOptions.Equip, ContextMenuOptions.Drop }
public enum ConsumableContextMenu { }
public enum InteractableContext Menu {}
*/