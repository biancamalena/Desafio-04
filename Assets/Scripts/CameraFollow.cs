using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jogador;       
    public float smoothSpeed = 0.125f;
    public Vector3 offset;            

    void LateUpdate()
    {
        if (jogador == null) return;

        float desiredX = jogador.position.x + offset.x;
        float smoothedX = Mathf.Lerp(transform.position.x, desiredX, smoothSpeed);

        transform.position = new Vector3(smoothedX, transform.position.y, transform.position.z);
    }
}

