using UnityEngine;

public class Serpente : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 6f;
    public float chaseDuration = 2f;

    private bool estaPerseguindo = false;
    private float chaseTimer = 0f;

    void Update()
    {
        if (estaPerseguindo)
        {
            chaseTimer -= Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);

            if (chaseTimer <= 0)
            {
                estaPerseguindo = false;
            }
        }
    }

    public void AproximarDoJogador()
    {
        estaPerseguindo = true;
        chaseTimer = chaseDuration;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthDisplay health = other.GetComponent<HealthDisplay>();
            if (health != null)
            {
                health.health--;
                Debug.Log("Jogador foi alcançado pela serpente!");
            }

            estaPerseguindo = false; 
        }
    }
}
