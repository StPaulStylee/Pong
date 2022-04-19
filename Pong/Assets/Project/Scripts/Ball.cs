using UnityEngine;

public class Ball : MonoBehaviour {
  [Tooltip("The minimum x-axis speed of the ball to start a turn")]
  public float MinXSpeed = 0.8f;
  [Tooltip("The maximum x-axis speed of the ball to start a turn")]
  public float MaxXSpeed = 1.2f;
  [Tooltip("The minimum y-axis speed of the ball to start a turn")]
  public float MinYSpeed = 0.8f;
  [Tooltip("The maximum y-axis speed of the ball to start a turn")]
  public float MaxYSpeed = 1.2f;
  [Tooltip("The percentage increase of ball speed per player paddle collision")]
  public float DifficultyMultiplier = 1.1f;
  [Tooltip("The message displayed on the canvas which is dependent upon the current ball speed")]
  [SerializeField]
  private string[] DifficultyMessage = { "Easy Peasy", "Average Joe", "Meh", "Impressive!", "Show Off!!", "INSANE!!!" };

  public string DifficultyMessageSelected { get; set; }
  
  [SerializeField]
  private float ballSpeed;
  private Rigidbody2D ballRigidBody;

  void Start() {
    DifficultyMessageSelected = DifficultyMessage[0];
    ballRigidBody = GetComponent<Rigidbody2D>();
    SetBallStartingVelocity();
    // Used to set difficulty message
    ballSpeed = Mathf.Abs(ballRigidBody.velocity.x);
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    Debug.Log(this.ballSpeed);
    GetComponent<AudioSource>().Play();
    if (collision.tag == "Limit") {
      // If the position of the limit on the y axis is greater than the ball's y axis position we know its the top limit
      // Also, check to see that the ball is moving upwards
      if (collision.transform.position.y > transform.position.y && ballRigidBody.velocity.y > 0) {
        // Maintain the balls velocity on x, but inverse it's velocity on y
        ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, -ballRigidBody.velocity.y);
      }
      if (collision.transform.position.y < transform.position.y && ballRigidBody.velocity.y < 0) {
        ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, -ballRigidBody.velocity.y);
      }
    }
    else if (collision.tag == "Paddle") {
      if (collision.transform.position.x < transform.position.x && ballRigidBody.velocity.x < 0) {
        ballRigidBody.velocity = new Vector2(-ballRigidBody.velocity.x * DifficultyMultiplier, ballRigidBody.velocity.y * DifficultyMultiplier);
      }
      if (collision.transform.position.x > transform.position.x && ballRigidBody.velocity.x > 0) {
        ballRigidBody.velocity = new Vector2(-ballRigidBody.velocity.x * DifficultyMultiplier, ballRigidBody.velocity.y * DifficultyMultiplier);
      }
      ballSpeed = Mathf.Abs(ballRigidBody.velocity.x);
      SetDifficultyMessage();
    }
  }

  private void SetBallStartingVelocity() {
    // Random.value returns a float between 0 and 1, so if its below 0.5 make the ball go down, otherwise go up
    ballRigidBody.velocity = new Vector2(Random.Range(MinXSpeed, MaxXSpeed) * (Random.value > 0.5f ? -1 : 1),
                                         Random.Range(MinYSpeed, MaxYSpeed) * (Random.value > 0.5f ? -1 : 1));
  }

  private void SetDifficultyMessage() {
    if (this.ballSpeed < 1.5) {
      DifficultyMessageSelected = DifficultyMessage[0];
    }
    else if (this.ballSpeed >= 1.5 && this.ballSpeed < 2) {
      DifficultyMessageSelected = DifficultyMessage[1];
    }
    else if (this.ballSpeed >= 2 && this.ballSpeed < 3) {
      DifficultyMessageSelected = DifficultyMessage[2];
    }
    else if (this.ballSpeed >= 3 && this.ballSpeed < 4.6) {
      DifficultyMessageSelected = DifficultyMessage[3];
    }
    else if (this.ballSpeed >= 4.6 && this.ballSpeed < 7) {
      DifficultyMessageSelected = DifficultyMessage[4];
    }
    else {
      DifficultyMessageSelected = DifficultyMessage[5];
    }
  }
}
