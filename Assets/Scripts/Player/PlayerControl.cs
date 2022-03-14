using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce = 500f;
    private float _upOrDown;

    public GameObject deathEffect;
    public AudioSource _jumpEffect, _duckEffect;

    Animator anim;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveControl();
    }

    private void MoveControl()
    {
        if (GameManager.gameStopped != true)
        {
            _upOrDown = CrossPlatformInputManager.GetAxisRaw("Vertical");

            if (_upOrDown > 0 && rb.velocity.y == 0)
            {
                rb.velocity = new Vector3(0, _jumpForce, 0);
                _jumpEffect.Play();
            }

            if (_upOrDown < 0 && rb.velocity.y == 0)
            {
                anim.SetBool("isDown", true);
                _duckEffect.Play();
            }
            else
            {
                anim.SetBool("isDown", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Obstacle"))
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
    }
}
