using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Pulo")]
    public float jumpForce = 7f;
    public float gravityScale = 2f;
    private bool isGrounded = true;

    [Header("Movimento")]
    public float velocidadeBase = 5f;
    private float multiplicadorVelocidade = 1f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float moveSpeed = velocidadeBase * multiplicadorVelocidade;
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    public void SetVelocidadeLenta(bool lento)
    {
        multiplicadorVelocidade = lento ? 0.4f : 1f; // Ajuste como quiser
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
