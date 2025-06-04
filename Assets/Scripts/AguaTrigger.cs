using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocaAgua : MonoBehaviour
{
      public float fatorLentidao = 0.5f; // Reduz para 50% da velocidade
    private float velocidadeOriginal;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MovimentoJogador movimento = other.GetComponent<MovimentoJogador>();
            if (movimento != null)
            {
                movimento.ModificarVelocidade(fatorLentidao);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MovimentoJogador movimento = other.GetComponent<MovimentoJogador>();
            if (movimento != null)
            {
                movimento.ModificarVelocidade(1f); // Volta ao normal
            }
        }
    }
}

  