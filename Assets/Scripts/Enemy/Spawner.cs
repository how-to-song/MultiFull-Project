using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Transform[] spawnPoints;
    private float spawnTimer = 0f;

    void Start()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= 2f)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = GameManager.instance.enemySpawnPool.Get(Random.Range(0, 2));
        enemy.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
    }
}
