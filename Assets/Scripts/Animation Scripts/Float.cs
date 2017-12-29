using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class Float : MonoBehaviour {

    // Holds Y position for floating
    private float positionY;

    // Sets speed for float
    [SerializeField]
    private float floatSpeed = 0.01f;

    // Set the offset for floating up and down
    [SerializeField]
    private float offset = 0.25f;

    // Holds max and min heights for floating animation
    private float maxHeight;
    private float minHeight;

    // Holds direction
    private bool isGoingUp = true;

    void Start ()
    {
        positionY = this.transform.position.y;
        maxHeight = positionY + offset;
        minHeight = positionY - offset;
    }

	void Update () {
        if (this.positionY <= maxHeight && isGoingUp)
        {
            this.SetTransformY(positionY += floatSpeed);
        }
        else if (this.positionY <= minHeight)
        {
            isGoingUp = true;
        }
        else
        {
            isGoingUp = false;
            this.SetTransformY(positionY -= floatSpeed);
        }
	}

    void SetTransformY (float pos)
    {
        this.transform.position = new Vector3(this.transform.position.x, pos, this.transform.position.z);
    }
}
