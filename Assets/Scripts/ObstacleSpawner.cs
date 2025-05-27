using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaculos;
    public float intervalo = 2f;
    public Transform pontoSpawn;

    private float tempoParaProximoSpawn;

    void Update()
    {
        tempoParaProximoSpawn -= Time.deltaTime;

        if (tempoParaProximoSpawn <= 0)
        {
            SpawnarObstaculo();
            tempoParaProximoSpawn = intervalo;
        }
    }

    void SpawnarObstaculo()
    {
        if (obstaculos.Length == 0 || pontoSpawn == null)
            return;

        int index = Random.Range(0, obstaculos.Length);

        Vector3 posicaoSpawn = pontoSpawn.position;
        posicaoSpawn.y += Random.Range(-0.5f, 0.5f);

        Instantiate(obstaculos[index], posicaoSpawn, Quaternion.identity);
    }
}
