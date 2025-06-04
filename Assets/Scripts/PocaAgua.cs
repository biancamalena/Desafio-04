using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaTrigger : MonoBehaviour
{
    public float duracaoLentidao = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            PlayerController jogador = other.GetComponent<PlayerController>();
            if (jogador != null)
            {
                jogador.SetVelocidadeLenta(true);
            }
        }
    }
       void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController jogador = other.GetComponent<PlayerController>();
            if (jogador != null)
            {
                jogador.SetVelocidadeLenta(false); // Volta à velocidade normal
            }
        }
    }
}

