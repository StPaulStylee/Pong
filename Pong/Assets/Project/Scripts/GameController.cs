using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Create a public variable in which our Bal Prefab can be added to the GameController Script comonent in the editor
    public GameObject BallPrefab;

    // This is a reference to our Ball component/script that lives in our BallPrefab
    private Ball currentBall;
    // Start is called before the first frame update
    void Start()
    {
        // Create an instance of our Ball Prefab and then place the ball in the game
        // We want the ball to be a child of our GameController
        GameObject ballInstance = Instantiate(BallPrefab, transform);
        currentBall = ballInstance.GetComponent<Ball>( );
        // NOTE: In the video they used a Vector3.zero but that doesn't seem necessary as this is a 2D game
        // Vector2.zero is shorthand for Vector2(0,0);
        currentBall.transform.position = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
