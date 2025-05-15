using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] posicoesCenarios; 
    public float velocidade = 5f;
    private int cenarioAtual = 0;
    private bool movendo = false;

    void Update()
    {
        if (movendo)
        {
            Vector3 alvo = posicoesCenarios[cenarioAtual].position;
            transform.position = Vector3.MoveTowards(transform.position, alvo, velocidade * Time.deltaTime);

            if (Vector3.Distance(transform.position, alvo) < 0.01f)
                movendo = false;
        }
    }

    public void IrParaCenario(int index)
    {
        if (index >= 0 && index < posicoesCenarios.Length)
        {
            cenarioAtual = index;
            movendo = true;
        }
    }
}
