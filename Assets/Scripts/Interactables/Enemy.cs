using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable {

    PlayerManager playerManager;
    CharacterStats stats;

    void Start()
    {
        // Get player manager so we can interact with enemy
        this.playerManager = PlayerManager.instance;

        // Get the stats of this enemy object
        this.stats = GetComponent<CharacterStats>();
    }

    public override void Interact()
    {
        base.Interact();

        // Get combat components of the player
        CharacterCombat playerCombat = this.playerManager.player.GetComponent<CharacterCombat>();

        if (playerCombat != null)
        {
            // Attack the stats of this object
            playerCombat.Attack(this.stats);
        }
    }
}
