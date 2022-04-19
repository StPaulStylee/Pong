using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject BallPrefab;
    public Text Score1Text;
    public Text Score2Text;
    public Text DifficultyText;
    // The location where we want to check if the ball has went beyond for scoring porpoises
    private float scoreCoordinates = 3.3f;

    private Ball currentBall;
    private int Score1 = 0;
    private int Score2 = 0;

    // static instance of Game Manager that can be accessed anywhere
    public static GameController Instance;

    private void Awake( )
    {
        // Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SpawnBall( );
        UpdateScore( );
    }

    void Update()
    {
        if (currentBall != null)
        {
            if (currentBall.transform.position.x > scoreCoordinates)
            {
                Score1++;
                Destroy(currentBall.gameObject);
                SpawnBall( );
                UpdateScore( );
            }
            else if (currentBall.transform.position.x < -scoreCoordinates)
            {
                Score2++;
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
