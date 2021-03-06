﻿using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public float Speed = 1f;
    public GameObject currentBall;

    private float SmoothTime = 0.01f;
    private Vector2 startPosition;
    private Vector2 velocity = Vector2.zero;
    // Start is called before the first frame update
    void Start( )
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentBall == null)
        {
            currentBall = GameObject.FindWithTag("Ball");
        }
        if (currentBall != null)
        {
            MoveAiPaddle( );
        }
    }

    private void MoveAiPaddle()
    {
        Vector2 ballPosition = currentBall.transform.position;
        Vector2 paddlePosition = this.transform.position;
        Vector2 targetPosition = new Vector2(startPosition.x, ballPosition.y);
        this.transform.position = Vector2.SmoothDamp(this.transform.position, targetPosition, ref velocity, SmoothTime, Speed);
    }
}
