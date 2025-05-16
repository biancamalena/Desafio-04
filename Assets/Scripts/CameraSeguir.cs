using UnityEngine;

public class CameraSeguir : MonoBehaviour
{
    public Transform jogador;
    public Vector3 offset = new Vector3(0f, 0f, -10f);

    void LateUpdate()
    {
        if (jogador != null)
        {
            transform.position = jogador.position + offset;
        }
    }
}

