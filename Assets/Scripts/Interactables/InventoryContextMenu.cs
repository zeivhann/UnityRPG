using UnityEngine;


// This class will handle the context menu for the Inventory
public class InventoryContextMenu : MonoBehaviour {

    public void GetInventoryContext()
    {
        // Find the context menu
        // Show context menu
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Show context menu");
        }
    }
	
}
