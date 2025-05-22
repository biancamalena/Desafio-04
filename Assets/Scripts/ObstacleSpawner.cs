using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    public float minY = -1f;
    public float maxY = 1f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        float y = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(transform.position.x, y, 0);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
