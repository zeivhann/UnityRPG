using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Constant global strings used by different parts of the game
    public const string CONTEXT_MENU_TITLE = "TMP_CONTEXT_MENU";

	// Use this for initialization
	void Start () {
		
	}
	
	// Exit game when Escape is pressed (This is used for executable` builds, should be updated eventually
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
