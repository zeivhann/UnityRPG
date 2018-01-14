using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class Float : MonoBehaviour {

    // Holds Y position for floating
    private float positionY;

    // Sets speed for float
    [SerializeField]
    private float floatSpeed = 0.5f;

    // Set the offset for floating up and down
    [SerializeField]
    private float offset = 0.25f;

    // Holds max and min heights for floating animation
    private float maxHeight;
    private float minHeight;

    // Holds direction
    private bool isGoingUp = true;


    void Awake ()
    {
        // Set positions
        this.positionY = this.transform.position.y;
        this.maxHeight = positionY + offset;
        this.minHeight = positionY - offset;
    }

	void Update () {
        // If position is less than the maxheight and it's currenlty going up, continue to go up
        if (this.positionY < (maxHeight) && isGoingUp)
        {
            this.SetTransformY(positionY += floatSpeed * Time.deltaTime);
        }
        else if (this.positionY <= minHeight)
        {
            this.isGoingUp = true;
        }
        else
        {
            this.isGoingUp = false;
            this.SetTransformY(positionY -= floatSpeed * Time.deltaTime);
        }
	}

    void SetTransformY (float pos)
    {
        this.transform.position = new Vector3(this.transform.position.x, pos, this.transform.position.z);
    }
}
