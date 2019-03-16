using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public float Speed = 1f;
    public GameObject currentBall;
    private Vector2 startPosition;
    // Start is called before the first frame update
    void Start( )
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentBall = GameObject.FindWithTag("Ball");
        if (currentBall != null)
        {
            Vector2 ballPosition = currentBall.transform.position;
            Vector2 paddlePosition = this.transform.position;
            if (paddlePosition.y > ballPosition.y)
            {
                //paddleposition.y -= this.speed;
                GetComponent<Rigidbody2D>( ).velocity = new Vector2(0, -1 * this.Speed);
            }
            else if (paddlePosition.y < ballPosition.y)
            {
                //paddlePosition.y += this.Speed;
                GetComponent<Rigidbody2D>( ).velocity = new Vector2(0, 1 * this.Speed);
            }
            // set the paddle location equal to the balls y location
            //GetComponent<Rigidbody2D>( ).velocity = new Vector2(startPosition.x, paddlePosition.y);
            //Debug.Log(currentBall.transform.position.y);
        }
    }
}
