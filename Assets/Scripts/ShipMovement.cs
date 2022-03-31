using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    private Rigidbody2D ship;

    private bool moving;

    private float direction;

    public float shipSpeed = 1.0f;

    public float turnSpeed = 1.0f;

    private void Awake()
    {
        ship = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //get the W and Up arrow key input to check if player is moving.
        moving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = 1.0f;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = -1.0f;
        } else
        {
            direction = 0.0f;
        }
    }

    //Update according to framerate
    private void FixedUpdate()
    {
        if (moving)
        {
            ship.AddForce(this.transform.up * this.shipSpeed);
        }

        if (direction != 0)
        {
            ship.AddTorque(direction * this.turnSpeed);
        }
    }
}
