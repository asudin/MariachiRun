using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUIGame : MonoBehaviour
{
    [SerializeField, Tooltip("Enemies that appear in UI.")]
    GameObject[] obstacles;
    [Space]

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

        newEnemy.transform.position = spawnPoint.position + new Vector3(0, Random.Range(-spawnHeight, spawnHeight), 0);

        //Instantiate(obstacles[randomObstacle], spawnPoint.position[Random.Range(-spawnHeight, spawnHeight)], Quaternion.identity);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
}
