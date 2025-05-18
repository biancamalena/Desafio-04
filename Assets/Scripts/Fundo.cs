using UnityEngine;

public class Fundo : MonoBehaviour
{
    public float velocidade = 5f;
    private float larguraTotal;
    private Vector3 posInicial;

    void Awake()
    {
        this.posInicial = transform.position;
        this.larguraTotal = GetComponentInChildren<SpriteRenderer>().size.x;
       
    }

    void Update()
    {
        // Move o fundo para a esquerda
        transform.Translate(Vector3.left * velocidade * Time.deltaTime);

        // Quando ele sair totalmente da tela, volta pro ponto inicial + largura * 2 (pra continuar o loop)
        if (transform.position.x < posInicial.x - larguraTotal)
        {
            transform.position = new Vector3(posInicial.x, transform.position.y, transform.position.z);
        }
    }
}
