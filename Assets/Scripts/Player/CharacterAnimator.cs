using UnityEngine.AI;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour {

    // Holds references to the animator and navmeshagent game objects
    Animator animator;
    NavMeshAgent agent;

    const float locomotionAnimationSmoothTime = 0.1f;
    

	// Grab references for member variables
	void Start () {
		agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        // We want to set the speed of the animation based on the current magnitude and the max speed of the navmeshagent
        // So we divide the cucrent magnitude by the max speed of the agent
        float speedPercent = this.agent.velocity.magnitude / this.agent.speed;

        // Here we set the float speed for the animator based on a given name in the editor (speedPercent in the blend tree)
        // We pass in the string literal of the name, the actual value for speed percent, and we give it a dampening time so that the animations are smoothly transitioned
        this.animator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);
	}
}
