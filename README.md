# UnityRPG
Basic RPG built in Unity. 
This is a work in progress while I learn the Unity engine and API.

To use UnityRPG, you'll want [Unity3D](https://unity3d.com/), a powerful development environment for creating games. This project is being build in v. 2017.3.x.

### Basic Aspects of Gameplay
**I. Interactables**

This is the class that every interactable object in the game inherits from. This will include doors, chests, items, NPCs, etc. Interactions are completed using left-click.
- Enemies are inherited from this class because combat relies heavily on player interaction.

**II. Items**

These are objects that can go into your inventory and they will all inherit from the base Item class. The Item class is based on Unity's ScriptableObject class which enables you to create objects that don't need to be attached to game objects.

- [Documentation for ScriptableObject](https://docs.unity3d.com/ScriptReference/ScriptableObject.html)
- Create an Item by right-clicking -> Create -> Inventory -> Item. From here, in the inspector the name, sprite in inventory and other item attributes can be set.

**III. Navigation**

Navigation is done by using a NavMeshRenderer that's built into Unity. The player can walk around to various points on the map and interact with objects by left-clicking.

**IV. Inventory**

The inventory is handled as its own class with a member variable list. This list contains the items in the inventory and how many items can be held in the inventory. It works by being attached to a GameManger in the scene. The class uses a singleton to call itself and act as a global variable so we don't have to find InstanceOf inventory. This ensures that we have a consistent inventory, and that we can always find it.

- [Documentation for Singletons](http://wiki.unity3d.com/index.php/Singleton)
- The inventory is actually kept track of by the GameManager object which holds the list and the list is accessed globablly and affected by lower parts of the hierarchy, typically through interactions with the inventory UI.
- The Inventory UI is created by drawing on a pane that uses a grid system and a prefab. The icons are selected and enabled based on looping through the list. If the item is in the list, the UI uses its attributes to draw it onto the pane, otherwise the UI simply empties the contents of the rest of the slots. In its current state, the bag is static and has a specific number of slots.
- The Inventory class holds the attributes of the inventory itself and notifies when the inventory has been altered in some way. This class also holds the actual list of inventory items.
- The InventoryUI class puts the items in the UI using a loop and sets the keybindings for showing and hiding the inventory. (The bag is initially hidden by disabling it in the Unity editor).
- The InventorySlot class holds the attributes and functions of each inventory slot itself--adding and removing items, as well as using items and the given attributes of the item, such as its sprite and name.

**V. Equipment**

The equipment is handled by the EquipmentManager script on the GameManager in the scene.
- Equipment uses an Enumerator to keep track of which slots each piece of equipment belongs to.
- Equipment inherits from Item.
- The EquipmentManager holds an array of Enums that holds each item to be equipped; when something is already equipped in the slot it swaps out and goes back into the inventory
- The meshes for the equipped items are similarly handled in an Enum that holds the location of where each piece of equipment belongs. Each equippable item is assigned both the Equip Slot (determed in equipped array) and Covered Mesh Regions (Which tells where the armor is covering on the player).

**VI. Stats**

Stats determine the effectiveness of items and bonuses given by weapons and armor.
- Every stat inherits from the Stat class which is its own standalone class. Stat has a base value which can be assigned in the inspector but when equipment has been added or removed, is affected by said equipment. This class has a list that holds the modifier values that increase or decrease the stat.
- CharacterStats applies to all characters and is intended to extend to other objects that need stats. Every character has a certain amount of max health which can be reduced to zero, in which case the character dies. This class contains functions that allow the character to take damage.
- PlayerStats inherits from CharacterStats and applies to the player character and handles the stats of the player. This class is where, when equipment has been changed, the modifiers are added or removed. This will then change the amount of damage the character takes, etc.

**VII. Enemies**

Enemies are controlled by the EnemyController class. Radius specifies aggro range of the enemy.
- Every instance of an enemy should use the Enemy class, which has a base class of Interactable. In doing this, it enables the player to interact with the enemies and we can override what happens when the player interacts with it. This is done by overriding the base Interact() class. Here we take into consideration enemy stats.

**VIII. Combat**

Combat is largely based on the CharacterCombat class, which covers all characters including the player and enemies.

**IX. Context Menus**

Context menus are handled with the ContextMenuHandler class.
- When items are created, they can be assigned options from the context menu options enumerator. In this way, items can have unique context menu options and can be easily assigned on a per-item basis.
- The ContextMenuHandler class relies on the Item class to create an empty GameObject to attach its script to, which it then deletes when it is either used or somewhere else on the screen is clicked.
- Context menu can be closed by pressing the inventory buttons or escape.

### Other Scripts
- **Float** - When put on a game object, floats up and down based on a given offset. Values can be set in editor.
- **CameraController** - This script controls the camera. Allows for zooming in and out and panning around in a circle around the player.
- **ConvertToRegularMesh** - This script is something to be put on any mesh so that it can be used in a scene quickly. Just drag a mesh into the editor window, add this component and click the gear icon context menu -> Convert To Regular Mesh. (May have to reset transform)
- **GameManager** - Handles pause menu/closing windows (eventually). Sits on the GameManager object. Also holds various constant strings which might need to be accessed in various parts of the game


##### TODOs and Other Things
- Reorganize asset hierarchy logically
- Add Interactive objects (i.e. open chest to get item)
- Make inventory canvas movable
- Open "Character/Equipment/Stats" window when player presses "C"
- Add more stats and create alogorithms to make them do different things for the player
- Create Game over screen
- Create Pause menu
- Add dialogue system
- Create more custom meshes?

___
_Because this is a first attempt at making an RPG system in Unity, I'm building off of [this fantastic series](https://www.youtube.com/playlist?list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7) from the great folks at Brackeys, including some of their assets from the series._

#### A few free Asset packages are used in this project.
[RPG Inventory Icons](https://assetstore.unity.com/packages/2d/gui/icons/rpg-inventory-icons-56687)

[Low Poly Free Pack](https://assetstore.unity.com/packages/3d/environments/low-poly-free-pack-63714)

##### Some free-for-commercial-use resources (to the best of my knowledge) for art and music are also used.

[Main menu background](https://www.wallpaperup.com/8163/Landscapes_dark_houses_bridges_fantasy_art_artwork_waterfalls.html)

Main menu Music - ["Legend" by Adrian von Ziegler](https://adrianvonziegler.bandcamp.com/)