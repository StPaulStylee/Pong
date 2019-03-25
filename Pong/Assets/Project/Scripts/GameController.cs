using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Create a public variable in which our Bal Prefab can be added to the GameController Script comonent in the editor
    public GameObject BallPrefab;
    public Text Score1Text;
    public Text Score2Text;
    public Text DifficultyText;
    // The location where we want to check if the ball has went beyond for scoring porpoises
    private float ScoreCoordinates = 3.3f;

    // This is a reference to our Ball component/script that lives in our BallPrefab
    private Ball currentBall;
    private int Score1 = 0;
    private int Score2 = 0;

    // static instance of Game Manager that can be accessed anywhere
    public static GameController Instance;

    // Called when the script is loaded
    private void Awake( )
    {
        // Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
        }
        // Make sure that it is equal to the current object
        else if (Instance != this)
        {
            // Destroy the current game object because we only need one and we already have it
            Destroy(gameObject);
        }
        // Don't destroy the gameObject when scene is changed - this is done by default
        DontDestroyOnLoad(gameObject);
        //hud = FindObjectOfType<HudManager>( );
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall( );
        UpdateScore( );
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBall != null)
        {
            if (currentBall.transform.position.x > ScoreCoordinates)
            {
                Score1++;
                //Score1Text.text = Score1.ToString( );
                // Always be sure to Destroy the ball before spawning the next
                // This would be a great opporunity to try implementings an object pool 
                Destroy(currentBall.gameObject);
                SpawnBall( );
                UpdateScore( );
            }
            else if (currentBall.transform.position.x < -ScoreCoordinates)
            {
                Score2++;
                //Score2Text.text = Score2.ToString( );
                Destroy(currentBall.gameObject);
                SpawnBall( );
                UpdateScore( );
            }
            UpdateDifficultyMessage( );
        }
    }

    private void SpawnBall()
    {
        // Create an instance of our Ball Prefab and then place the ball in the game
        // We want the ball to be a child of our GameController
        GameObject ballInstance = Instantiate(BallPrefab, transform);
        currentBall = ballInstance.GetComponent<Ball>( );
        // NOTE: In the video they used a Vector3.zero but that doesn't seem necessary as this is a 2D game
        // Vector2.zero is shorthand for Vector2(0,0);
        currentBall.transform.position = Vector2.zero;
    }

    private void UpdateDifficultyMessage( )
    {
        DifficultyText.text = currentBall.DifficultyMessageSelected;
    }

    private void UpdateScore( )
    {
        Score1Text.text = Score1.ToString( );
        Score2Text.text = Score2.ToString( );
    }
}
