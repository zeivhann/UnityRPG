using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Show fields of this class in the inspector
[System.Serializable]
public class Stat {
    [SerializeField]
    private int baseValue;

    // List of modifiers on object
    private List<int> modifiers = new List<int>();

    // Returns value of stat
    public int GetValue()
    {
        // Take modifiers into account when calculating stats
        int finalValue = baseValue;
        
        // loop through each modifier in the modifier list and add the values to finalValue
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }

    // Add modifier to object
    public void AddModifier (int modifier)
    {
        if (modifier != 0) modifiers.Add(modifier);
    }

    // Remove modifier from object
    public void RemoveModifier(int modifier)
    {
        if (modifier != 0) modifiers.Remove(modifier);
    }
}
