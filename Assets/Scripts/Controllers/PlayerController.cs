using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {
    // Using a layermask as a filter will prevent the player from focusing items we don't want focused
    public LayerMask movementMask;

    // Keeps track of what player currently has focused
    public Interactable focus;

    // Stores instance of camera
    Camera cam;

    // Stores Player Motor object to control player movement
    PlayerMotor motor;

	// Use this for initialization
	void Start () {
        // Get main camera
        this.cam = Camera.main;

        // Get player motor control
        this.motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {

        // Prevent player movement when clicking on UI
        if (EventSystem.current.IsPointerOverGameObject()) return;


        // Check if left mouse button is clicked
		if (Input.GetMouseButtonDown(0))
        {
            // Do a raycast from mouse position
            // If it hits, move player to where the raycast hit
            Ray ray = this.cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                // Move player to what was hit
                this.motor.MoveToPoint(hit.point);

                // Stop focusing any objects
                this.RemoveFocus();
            }

            // check if interactible
            if (Physics.Raycast(ray, out hit, 100))
            {
                // check if interactible
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                // If interactable set focus to object
                if (interactable != null)
                {
                    this.SetFocus(interactable);
                }
            }
        }

	}

    // Set player focus
    void SetFocus (Interactable newFocus)
    {
        // If there is already a focus, we want to defocus that first
        if (newFocus != this.focus)
        {
            if (this.focus != null) this.focus.OnDefocus();

            this.focus = newFocus;
            this.motor.FollowTarget(newFocus);
        }

        newFocus.OnFocus(this.transform);
    }

    // Remove player focus
    void RemoveFocus()
    {
        if (this.focus != null) this.focus.OnDefocus();

        this.focus = null;
        this.motor.StopFollowingTarget();
    }
}
