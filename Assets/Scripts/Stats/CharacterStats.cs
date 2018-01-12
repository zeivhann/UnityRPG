using UnityEngine;

public class CharacterStats : MonoBehaviour {
    public int maxHealth = 100;

    // Any class can get, only this class can set value
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    void Awake()
    {
        currentHealth = maxHealth;
    }


    // Apply damage to character
    public void TakeDamage (int damage)
    {
        // Reduce damage by the value of armor
        damage -= this.armor.GetValue();
        
        // Make sure that damage does not go below zero, otherwise the damage will "heal" the player
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        // Subtract damage from health
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage!");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // Die
        // Overwrite this function to apply to the death of a specific target
        Debug.Log(transform.name + " has died.");
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }
}
