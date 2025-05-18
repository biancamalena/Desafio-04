using UnityEngine;

public class CameraAndar : MonoBehaviour
{
    public float velocidade = 2f;

    void Update()
    {
        transform.position += new Vector3(velocidade * Time.deltaTime, 0, 0);
    }
}