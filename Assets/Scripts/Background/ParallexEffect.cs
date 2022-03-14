using UnityEngine;

public class ParallexEffect : MonoBehaviour
{
    public float _movingSpeed = 2f;
    public float _parallexEffect;
    private Vector2 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _movingSpeed * Time.deltaTime);

        if (transform.position.x < -_parallexEffect)
        {
            transform.position = _startPosition;
        }
    }
}
