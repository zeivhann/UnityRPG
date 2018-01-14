using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    // Target to follow
    public Transform target;

    // Amount to offset the camera angle by
    public Vector3 offset;

    // Speed at which to zoom
    public float zoomSpeed = 4f;

    // Min and max values for zoom distance
    public float minZoom = 2.8f;
    public float maxZoom = 8f;

    // Zoom factor
    private float currentZoom = 4.5f;

    // Offset to raise the camera from the bottom of player
    private float pitch = 2f;

    // amounts to pan the camera around the player
    public float yawSpeed = 100f;
    private float currentYaw = 0f;

    void Update ()
    {
        // Once per frame, if the scrollwheel is used, change current zoom to this amount.
        // This will allow the player to scroll in and out.
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        // Clamp this value so player cannot zoom out beyond defined boundaries
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        // if horizontal controls are used to pan around the character
        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }
	
	// Late update is called after update function so player can initiate movement
	void LateUpdate () {
        // move camera to position and offset it to align with player
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        // Rotate the camera around the player based on the yawInput
        transform.RotateAround(target.position, Vector3.up, currentYaw);
	}
}
