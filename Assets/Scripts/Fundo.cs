using UnityEngine;

public class Fundo : MonoBehaviour
{
    public float velocidade = 5f;
    private float larguraTotal;
    private Vector3 posInicial;

    void Start()
    {
        posInicial = transform.position;

        // Calcula a largura total somando os bounds dos filhos
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        float minX = float.MaxValue;
        float maxX = float.MinValue;

        foreach (SpriteRenderer sr in sprites)
        {
            float left = sr.bounds.min.x;
            float right = sr.bounds.max.x;

            if (left < minX) minX = left;
            if (right > maxX) maxX = right;
        }

        larguraTotal = maxX - minX;
    }

    void Update()
    {
        // Move para a esquerda
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);

        // Reposiciona o fundo se ele saiu da tela
        if (transform.position.x < posInicial.x - larguraTotal)
        {
            transform.position += Vector3.right * larguraTotal * 2f;
        }
    }
}


