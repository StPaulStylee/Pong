using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float Speed = 1f;
    public int PlayerIndex = 1;

    // Update is called once per frame
    void Update()
    {
        float verticalMovement = Input.GetAxis("Vertical" + PlayerIndex);
        GetComponent<Rigidbody2D>( ).velocity = new Vector2(0, verticalMovement * Speed);
    }
}
