using UnityEngine;

public class Interactable : MonoBehaviour {
    // How close to the object the player needs to be to interact
    public float radius = 3f;

    // This value specifies the interaction point that we want to use on an item
    // For example, if using a chest we want the player to have to go to the front of the chest to interact with it
    // We will use an empty game object to represent this
    public Transform interactionTransform;

    // Holds whether object is focused
    bool isFocus = false;
    
    // Holds the transform attributes of the player
    Transform player;

    bool hasInteracted = false;

    void Update()
    {
        // if this object is focused and the distance is within the defined radius, interact with object
        if (this.isFocus && !this.hasInteracted)
        {
            float distance = Vector3.Distance(this.player.position, this.interactionTransform.position);
            if (distance <= this.radius)
            {
                Interact();
                this.hasInteracted = true;
            }
        }
    }

    // Focus target
    public void OnFocus (Transform playerTransform)
    {
        this.isFocus = true;
        this.player = playerTransform;
        this.hasInteracted = false;
    }

    // Defocus target
    public void OnDefocus ()
    {
        this.isFocus = false;
        this.player = null;
        this.hasInteracted = false;
    }

    // Interaction; Intended to be overwritten so that interactions can be different for different objects
    public virtual void Interact ()
    {
        Debug.Log("Interacting with " + this.transform.name);
    }

    // Draw gizmo when object is selected in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.interactionTransform.position, radius);
    }
}
