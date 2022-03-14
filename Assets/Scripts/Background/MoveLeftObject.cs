using UnityEngine;

public class MoveLeftObject : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;

    [SerializeField]
    private float _rightWayPointX = -15f, _leftWayPointX = 15f;

    private void Update()
    {
        //Moving the objects from the left to the right side
        transform.position = new Vector2(transform.position.x + _moveSpeed * Time.deltaTime,
            transform.position.y);

        //Clouds reappear if outside of set boundaries
        if (transform.position.x < _leftWayPointX)
        {
            transform.position = new Vector2(_rightWayPointX, transform.position.y);
        }
    }
}
