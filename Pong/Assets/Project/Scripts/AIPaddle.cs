using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
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
            // set the paddle location equal to the balls y location
            GetComponent<Rigidbody2D>( ).position = new Vector2(startPosition.x, currentBall.transform.position.y);
            Debug.Log(currentBall.transform.position.y);
        }
    }
}
