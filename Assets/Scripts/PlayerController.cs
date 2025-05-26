using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Pulo")]
    public float jumpForce = 7f;
    public float gravityScale = 2f;
    private bool isGrounded = true;

    [Header("Lentidão")]
    public float slowDuration = 2f;
    private bool isSlowed = false;
    private float slowTimer = 0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        // Timer para acabar lentidão
        if (isSlowed)
        {
            slowTimer -= Time.deltaTime;
            if (slowTimer <= 0f)
            {
                isSlowed = false;
                // Aqui você pode acionar algo como informar o cenário que o jogador voltou ao normal
            }
        }
    }

    public void SlowDown(float duration)
    {
        isSlowed = true;
        slowTimer = duration;
        // Aqui você pode notificar o cenário ou o controlador da serpente para se aproximar
        Debug.Log("Jogador ficou lento!");
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
        else if (col.CompareTag("Obstaculo"))
        {
            SlowDown(slowDuration);
        }
    }
}
