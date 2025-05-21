using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float slowSpeed = 2f;
    private float currentSpeed;

    private Rigidbody2D rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = normalSpeed;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * currentSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            currentSpeed = slowSpeed;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            currentSpeed = normalSpeed;
        }
    }
}

