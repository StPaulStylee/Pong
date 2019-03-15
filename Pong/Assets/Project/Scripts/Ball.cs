using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float MinXSpeed = 0.8f;
    public float MaxXSpeed = 1.2f;
    public float MinYSpeed = 0.8f;
    public float MaxYSpeed = 1.2f;
    // 10% difficulty increase
    public float DifficultyMultiplier = 1.1f;
    // Will be private once settled on text
    public string[] DifficultyMessage = {"Easy Peasy", "Average Joe", "Ok, now I'm Impressed", "Show Off!", "INSANE!!!"};

    private Rigidbody2D ballRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>( );
        // Set the starting velocity to a random number between our defined ranges
        // Random.value returns a float between 0 and 1, so if its below 0.5 make it go down, otherwise go up
        ballRigidBody.velocity = new Vector2(Random.Range(MinXSpeed, MaxXSpeed) * (Random.value > 0.5f ? -1 : 1), 
                                             Random.Range(MinYSpeed, MaxYSpeed) * (Random.value > 0.5f ? -1 : 1));
    }

    // This doesn't have to be called in another method because it calls itself when it enters a collider... Hence the name ; )
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<AudioSource>( ).Play( );
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
                ballRigidBody.velocity = new Vector2(-ballRigidBody.velocity.x * DifficultyMultiplier, ballRigidBody.velocity.y * DifficultyMultiplier);
            }
            if (collision.transform.position.x > transform.position.x && ballRigidBody.velocity.x > 0)
            {
                ballRigidBody.velocity = new Vector2(-ballRigidBody.velocity.x * DifficultyMultiplier, ballRigidBody.velocity.y * DifficultyMultiplier);
            }

        }
    }
}
