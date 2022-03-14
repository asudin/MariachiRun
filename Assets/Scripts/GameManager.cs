using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject deathScreen;
    [Space]

    [Header("SCORE")]
    [SerializeField]
    Text highScoreText;

    [SerializeField]
    Text playerScoreText;

    [SerializeField]
    Text deathScoreText;
    [Space]

    [Header("OBSTACLES")]
    [SerializeField]
    GameObject[] obstacles;

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    private float spawnRate = 2f;
    private float nextSpawn;

    [SerializeField]
    private float timeToBoost = 5f;
    private float nextBoost;

    private int highScore = 0, playerScore = 0;

    public static bool gameStopped;
    public static GameManager instance;

    private float nextScoreIncrease = 0f;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //Game is not paused
        Time.timeScale = 1f;
        gameStopped = false;

        deathScreen.SetActive(false);

        //Initializing player score settings
        playerScore = 0;
        highScore = PlayerPrefs.GetInt("highscore");
        
        //Game speed and enemy spawning rates
        nextSpawn = Time.time + spawnRate;
        nextBoost = Time.time + nextBoost;
    }

    private void Update()
    {
        if(!gameStopped)
        {
            IncreasePlayerScore();
        }

        //Viewing the scores on the screen
        highScoreText.text = "High score: " + highScore;
        playerScoreText.text = "Your score: " + playerScore;

        if (Time.time > nextSpawn)
        {
            SpawnObstacle();
        }

        if (Time.unscaledTime > nextBoost && !gameStopped)
        {
            BoostTime();
        }
    }

    public void GameOver()
    {
        //If player scored more than highscore set new highscore
        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("highscore", playerScore);
        }

        Time.timeScale = 0;

        gameStopped = true;
        deathScreen.SetActive(true);

        //Show player score and disable active game screen scores
        deathScoreText.text = "Your score: " + playerScore;
        
        playerScoreText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
    }

    //Spawn random enemies obstacles in front of player
    void SpawnObstacle()
    {
        nextSpawn = Time.time + spawnRate;

        int randomObstacle = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[randomObstacle], spawnPoint.position, Quaternion.identity);
    }

    //Speeding up the game every n-seconds
    void BoostTime()
    {
        nextBoost = Time.unscaledTime + timeToBoost;
        Time.timeScale += 0.25f;
    }

    //Increase player score with each second passing by
    void IncreasePlayerScore()
    {
        if (Time.unscaledTime > nextScoreIncrease)
        {
            playerScore += 1;
            nextScoreIncrease = Time.unscaledTime + 1;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
