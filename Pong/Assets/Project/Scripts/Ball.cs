﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Speed = 1f;

    private Rigidbody2D ballRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>( );
        ballRigidBody.velocity = new Vector2(-0.5f, Speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This doesn't have to be called in another method because it calls itself when it enters a collider... Hence the name ; )
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Limit")
        {
            // If the position of the limit on the y axis is greater than the ball's y axis position we know its the top limit
            // Also, check to see that the ball is moving upwards
            if (collision.transform.position.y > transform.position.y && ballRigidBody.velocity.y > 0 )
            {
                // Maintain the balls velocity on x, but inverse it's velocity on y
                ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, -ballRigidBody.velocity.y);
            }
            if (collision.transform.position.y < transform.position.y && ballRigidBody.velocity.y < 0)
            {
                ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, -ballRigidBody.velocity.y);
            }
        }
        else if (collision.tag == "Paddle")
        {
            if (collision.transform.position.x < transform.position.x && ballRigidBody.velocity.x < 0)
            {
                ballRigidBody.velocity = new Vector2(-ballRigidBody.velocity.x, ballRigidBody.velocity.y);
            }
            if (collision.transform.position.x > transform.position.x && ballRigidBody.velocity.x > 0)
            {
                ballRigidBody.velocity = new Vector2(-ballRigidBody.velocity.x, ballRigidBody.velocity.y);
            }
        }
    }
}
