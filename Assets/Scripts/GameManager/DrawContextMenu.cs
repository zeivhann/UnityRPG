using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawContextMenu : MonoBehaviour{

    // Make this accessible to all objects in scene
    /*
    #region Singleton

    public static DrawContextMenu instance;

    void Awake()
    {
        instance = this;
    }

    #endregion
     * */

    // text member variable to print on GUI
    string[] text;

    // checks to see if it was just initially clicked
    bool isClicked = false;

    // Holds values for initial mouse click
    float mouseX;
    float mouseY;

    string choice;

    Equipment equipment;
    Item item;

    // place options into string array
    public void SetContextMenu (Item item)
    {
        this.text = new string[item.contextMenu.Length];
        
        for (int i = 0; i < this.text.Length; i++)
        {
            this.text[i] = item.contextMenu[i].ToString();
        }

        this.item = item;
        this.equipment = (Equipment) item;
    }

	public string ShowMenu(string[] options)
    {
        this.text = options;

        return this.choice;
    }

    void OnGUI ()
    {
        // Draw the GUI button. For the second argument we enter the Y value which is the screen height minus the mouse position, which we adjust by multiplying the current index by the height of each button
        
        // First, we want to see if this is the initial click. If it is, we want to grab only the initial mouse position for x and y and then set isClicked to false
        if (!isClicked)
        {
            this.mouseX = Input.mousePosition.x;
            this.mouseY = Input.mousePosition.y;
            isClicked = true;
        }

        // Then we use the previous values in this equation
        if (this.text != null)
        {
            for (int i = 0; i < this.text.Length; i++)
            {
                // GUI.Button returns a boolean to check if it has been clicked or not
                bool isBtnClicked = GUI.Button(new Rect(this.mouseX, (Screen.height - (this.mouseY - (25 * i))), 100, 25), this.text[i]);

                if (isBtnClicked)
                {
                    if (this.text[i].Equals("Equip"))
                    {
                        this.choice = "Equip";
                        this.equipment.MakeChoice("Equip");
                        DeleteContextMenu();
                    }
                    else if (this.text[i].Equals("Drop"))
                    {
                        this.choice = "Drop";
                        this.equipment.MakeChoice("Drop");
                        DeleteContextMenu();
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Inventory"))
        {
            DeleteContextMenu();
        }
    }

    string GetChoice()
    {
        return this.choice;
    }

    void DeleteContextMenu ()
    {
        Destroy(GameObject.Find(GameManager.CONTEXT_MENU_TITLE));
    }
}
