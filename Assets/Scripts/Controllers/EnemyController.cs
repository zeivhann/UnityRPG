using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
    // Aggro radius of the enemy
    public float lookRadius = 10f;

    // Get the location of the player/target as well as a reference to the navmeshagent so the enemy can move
    Transform target;
    NavMeshAgent agent;

    // Combat stats for this enemy
    CharacterCombat combat;

	// Use this for initialization
	void Start () {
        // Get Player position
        this.target = PlayerManager.instance.player.transform;

        // Get NavMeshAgent
		this.agent = GetComponent<NavMeshAgent>();

        // Get combat stats for this enemy
        this.combat = GetComponent<CharacterCombat>();
	}
	
	void Update () {
        // Get distance from current enemy position to target's position
        float distance = Vector3.Distance(this.target.position, this.transform.position);
		
        // If the target is within radius, follow target
        if (distance <= this.lookRadius)
        {
            this.agent.SetDestination(this.target.position);

            if (distance <= this.agent.stoppingDistance)
            {
                CharacterStats targetStats = this.target.GetComponent<CharacterStats>();

                // Attack the target's stats
                if (targetStats != null) this.combat.Attack(targetStats);

                // Face the target
                FaceTarget();
            }
        }
	}

    // Look at target
    void FaceTarget()
    {
        // Get the direction of the target
        Vector3 direction = (this.target.position - this.transform.position).normalized;

        // Rotation where we can point to the target
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        // Update current rotation of enemy. Slerp enables a smooth transform
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // Draw a wireframe for the radius around the enemy for a visualization in the editor
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
