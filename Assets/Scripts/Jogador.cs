using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float velocidade = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimento horizontal contínuo (direita)
        rb.velocity = new Vector2(velocidade, rb.velocity.y);
    }
}