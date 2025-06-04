using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class MovimentoJogador : MonoBehaviour
{
    public float velocidadeBase = 5f;
    private float modificadorVelocidade = 1f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 movimento = new Vector3(h, v, 0f);
        transform.Translate(movimento.normalized * velocidadeBase * modificadorVelocidade * Time.deltaTime);
    }

    public void ModificarVelocidade(float novoModificador)
    {
        modificadorVelocidade = novoModificador;
    }
}