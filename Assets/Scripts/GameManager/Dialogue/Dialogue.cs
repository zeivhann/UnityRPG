using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    #region Singleton
    // Use this to find the instance of Inventory that we want to use and keep constant
    public static Dialogue instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Dialogue Found.");
            return;
        }

        instance = this;
    }

    #endregion

    public string name;

    [TextArea(4, 12)] // Set size of textarea
    public string[] sentences;
}
