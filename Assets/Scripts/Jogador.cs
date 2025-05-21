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
       
        rb.velocity = new Vector2(velocidade, rb.velocity.y);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (col.CompareTag("guarana"))
        {
            GetComponent<HealthDisplay>().health++;
        }
    }
}