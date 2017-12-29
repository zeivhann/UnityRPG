using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// Requires player to have navmeshagent
[RequireComponent(typeof(NavMeshAgent))]

public class PlayerMotor : MonoBehaviour {
    // Holds NavMeshAgent object so player can move in game
    NavMeshAgent agent;

    // Target for player to follow when selected
    Transform target;

	// Use this for initialization
	void Start ()
    {
        // Get NavMeshAgent component
        this.agent = GetComponent<NavMeshAgent>();
	}

    void Update()
    {
        StartCoroutine("SetDestination");
    }
	
	// Move player to specified point given by raycast
	public void MoveToPoint (Vector3 point)
    {
        this.agent.SetDestination(point);
	}

    // Set target for player to follow when selected
    public void FollowTarget(Interactable newTarget)
    {
        this.agent.stoppingDistance = newTarget.radius * .8f;
        this.target = newTarget.interactionTransform;
        this.agent.updateRotation = false;
    }

    // Stop following a target
    public void StopFollowingTarget()
    {
        this.agent.stoppingDistance = 0f;
        this.agent.updateRotation = true;
        this.target = null;
    }

    // Face moving target, fixes issue where character doesn't turn in time with target unless it is outside of the radius
    void FaceTarget ()
    {
        // Get direction towards target
        Vector3 direction = (target.position - transform.position).normalized;

        // We pass in 0 to the Y because we don't want the character to look up
        // Find rotation to look in that direction by taking values from direction
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

        // Smoothly interpolate to that rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // Coroutine: Have player move to destination of focus even if focus is moving
    IEnumerator SetDestination()
    {
        if (this.target != null)
        {
            this.agent.SetDestination(this.target.position);
            FaceTarget();
        }
        yield return null;
    }
}
