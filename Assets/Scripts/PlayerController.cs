using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float normalSpeed = 5f;
    public float slowSpeed = 2f;
    private float currentSpeed;

    [Header("Pulo")]
    public float jumpForce = 7f;
    public float gravityScale = 2f;
    private bool isGrounded = true;

    [Header("Lentidão")]
    private bool isSlowed = false;
    private float slowTimer = 0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
        currentSpeed = normalSpeed;
    }

    void Update()
    {
        Debug.Log("Velocidade: " + currentSpeed);

        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        if (isSlowed)
        {
            slowTimer -= Time.deltaTime;
            if (slowTimer <= 0f)
            {
                isSlowed = false;
                currentSpeed = normalSpeed;
            }
        }
    }

    public void SlowDown(float duration)
    {
        isSlowed = true;
        slowTimer = duration;
        currentSpeed = slowSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("guarana"))
        {
            GetComponent<HealthDisplay>().health++;
            Destroy(col.gameObject); 
        }
    }
}
