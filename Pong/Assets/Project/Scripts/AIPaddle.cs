using UnityEngine;

public class AIPaddle : MonoBehaviour
{
  [Tooltip("The speed at which the AIPaddle can move. This is essentially a difficulty setting")]
    public float Speed = 1f;

    private GameObject currentBall;
    private float smoothTime = 0.01f;
    private Vector2 startPosition;
    private Vector2 velocity = Vector2.zero;
    // Start is called before the first frame update
    void Start( )
    {
        startPosition = transform.position;
    }

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
        Vector2 targetPosition = new Vector2(startPosition.x, ballPosition.y);
        this.transform.position = Vector2.SmoothDamp(this.transform.position, targetPosition, ref velocity, smoothTime, Speed);
    }
}
