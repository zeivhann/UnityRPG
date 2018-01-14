using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {

	// Tell Equipment Manager that equipment has been changed and run OnEquipmentChanged
	void Start () {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}

    // When equipment has been changed, add/remove modifiers
    void OnEquipmentChanged(Equipment newEquipment, Equipment oldEquipment)
    {
        // Add new modifiers
        if (newEquipment != null)
        {
            this.armor.AddModifier(newEquipment.armorModifier);
            this.damage.AddModifier(newEquipment.damageModifier);
        }

        // Remove old modifiers
        if (oldEquipment != null)
        {
            this.armor.RemoveModifier(oldEquipment.armorModifier);
            this.armor.RemoveModifier(oldEquipment.damageModifier);
        }
    }

    public override void Die()
    {
        base.Die();

        // Kill the player
        PlayerManager.instance.KillPlayer();
    }
}
