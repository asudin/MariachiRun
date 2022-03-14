using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    [SerializeField]
    float _obstacleSpeed = -5f;

    private void Update()
    {
        //Move the obstacles towards the player
        transform.position = new Vector2(transform.position.x + _obstacleSpeed * Time.deltaTime,
            transform.position.y);

        //Destroy obstacle when out of screen boundaries
        if (transform.position.x < -13f)
        {
            Destroy(gameObject);
        }
    }

    //Game over screen on obstacle collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            GameManager.instance.GameOver();
        }
    }
}
