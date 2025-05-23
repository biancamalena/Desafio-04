using UnityEngine;

public class MoverObstaculo : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);
    }
}

