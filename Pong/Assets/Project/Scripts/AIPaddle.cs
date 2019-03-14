using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public Ball currentBall;
    // Start is called before the first frame update
    void Start()
    {
        currentBall = GameController.Instance.BallPrefab.GetComponent<Ball>( );
    }

    // Update is called once per frame
    void Update()
    {
        // set the paddle location equal to the balls y location
        GetComponent<Rigidbody2D>( ).velocity = new Vector2(0, currentBall.transform.position.y);
        Debug.Log(currentBall.transform.position.y);
    }
}
