using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIGame : MonoBehaviour
{
    [Header("UI OBSTACLES")]
    [SerializeField, Tooltip("Enemies that appear in UI.")]
    GameObject[] obstacles;

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    private float spawnRate = 4f;
    private float nextSpawn;
    private int spawnHeight = 2;

    public static bool gameStopped;
    public static GameManager instance;

    private void Start()
    {
        //Game is not paused
        Time.timeScale = 1f;
        gameStopped = false;

        //Game speed and enemy spawning rates
        nextSpawn = Time.time + spawnRate;
    }

    private void Update()
    {
        if (Time.time > nextSpawn)
        {
            SpawnObstacle();
        }
    }

    //Spawn random enemies obstacles in front of player
    void SpawnObstacle()
    {
        nextSpawn = Time.time + spawnRate;

        int randomObstacle = Random.Range(0, obstacles.Length);
        GameObject newEnemy = Instantiate(obstacles[randomObstacle]);

        //Randomly change the spawned obstacle position for UI aesthetics
        newEnemy.transform.position = new Vector2(spawnPoint.position.x, Random.Range(-spawnHeight, spawnHeight));
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
