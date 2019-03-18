using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public float Speed = 1f;
    public GameObject currentBall;
    private Vector2 startPosition;
    private Rigidbody2D paddle;
    // Start is called before the first frame update
    void Start( )
    {
        startPosition = transform.position;
        paddle = GetComponent<Rigidbody2D>( );
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentBall == null)
        {
            Debug.Log("FOUND THE NEW BALL!");
            currentBall = GameObject.FindWithTag("Ball");
        }

        if (currentBall != null)
        {
            Vector2 ballPosition = currentBall.transform.position;
            Vector2 paddlePosition = this.transform.position;
            if (paddlePosition.y > ballPosition.y)
            {
                //paddleposition.y -= this.speed;
                //paddle.velocity = new Vector2(0, -1 * this.Speed);
                paddle.velocity = Vector2.Lerp(Vector2.zero, Vector2.down * this.Speed, 0.5f);
                //this.transform.position = new Vector2(startPosition.x, paddlePosition.y - (this.Speed * Time.deltaTime));
            }
            else if (paddlePosition.y < ballPosition.y)
            {
                //paddlePosition.y += this.Speed;
                //paddle.velocity = new Vector2(0, 1 * this.Speed);
                paddle.velocity = Vector2.Lerp(Vector2.zero, Vector2.up * this.Speed, 0.5f);
                //this.transform.position = new Vector2(startPosition.x, paddlePosition.y + (this.Speed * Time.deltaTime));
            }
            // set the paddle location equal to the balls y location
            //GetComponent<Rigidbody2D>( ).velocity = new Vector2(startPosition.x, paddlePosition.y);
            //Debug.Log(paddle.velocity);
        }
    }
}
