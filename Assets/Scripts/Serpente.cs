using UnityEngine;

public class Serpente : MonoBehaviour
{
    public Transform player;
    public float normalSpeed = 4f;
    public float chaseSpeed = 6f;

    private float currentSpeed;

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < 5f) 
        {
            currentSpeed = chaseSpeed;
        }
        else
        {
            currentSpeed = normalSpeed;
        }

        transform.position = Vector2.MoveTowards(transform.position, player.position, currentSpeed * Time.deltaTime);
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
        }
    }
}

