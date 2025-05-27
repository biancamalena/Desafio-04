using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Serpente serpente = FindObjectOfType<Serpente>();
            if (serpente != null)
            {
                serpente.AproximarDoJogador();
            }

            Destroy(gameObject);
        }
    }
}