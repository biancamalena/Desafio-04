using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coletavel : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        // Move para a esquerda
        transform.Translate(Vector3.left * velocidade * Time.deltaTime);
    }

}
