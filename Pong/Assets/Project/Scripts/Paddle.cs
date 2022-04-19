using UnityEngine;

public class Paddle : MonoBehaviour {
  [Tooltip("The speed to be applied to the paddles movement direction")]
  public float Speed = 1f;
  [Tooltip("Player 1 or Player 2 (used for player input assignement")]
  public int PlayerIndex = 1;

  void FixedUpdate() {
    float verticalMovement = Input.GetAxis("Vertical" + PlayerIndex);
    GetComponent<Rigidbody2D>().velocity = new Vector2(0, verticalMovement * Speed);
  }
}
