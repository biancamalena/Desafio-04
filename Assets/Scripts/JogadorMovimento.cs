using UnityEngine;

public class JogadorMovimento : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }
}
