
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
}
