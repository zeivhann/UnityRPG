using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Handles combat for all characters, including enemies and the player */

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {
    // Set attack speed cooldown time so player can't attack constantly
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;

    public float attackDelay = 0.6f;

    // Quick delegate to notify of attack
    public event System.Action OnAttack;

    // Stats of this object
    CharacterStats stats;

    void Start ()
    {
        // Get this object's character stats
        this.stats = GetComponent<CharacterStats>();
    }

    void Update ()
    {
        attackCooldown -= Time.deltaTime;
    }

    // Get damage from character stats of enemy
	public void Attack (CharacterStats targetStats)
    {
        // Deal damage to enemy if attack cooldown has been met
        if (this.attackCooldown <= 0f)
        {
            // Start coroutine
            StartCoroutine(DealDamage(targetStats, this.attackDelay));

            if (OnAttack != null) OnAttack();

            targetStats.TakeDamage(this.stats.damage.GetValue());

            // Reset attack cooldown
            this.attackCooldown = 1f / this.attackSpeed;
        }
    }

    // Coroutine to deal damage only when the animation is actually colliding with enemy
    IEnumerator DealDamage (CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(this.stats.damage.GetValue());
    }
}
