using UnityEngine;

public class DestruirForaDaTela : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x < -20f) 
        {
            Destroy(gameObject);
        }
    }
}

