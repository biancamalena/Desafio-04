using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float slowDuration = 2f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.SlowDown(slowDuration);
                Destroy(gameObject);
            }
        }
    }
}
