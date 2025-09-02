using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject coinPrefab;        // Prefab da moeda
    public float spawnInterval = 2f;     // Tempo entre cada spawn
     public Vector2 spawnArea = new Vector2(10f, 5f); // largura e altur

    void Start()
    {
        StartCoroutine(SpawnCoinsOverTime());
    }

    IEnumerator SpawnCoinsOverTime()
    {
        while (true)
        {
            SpawnCoin();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnCoin()
    {
        Vector2 spawnPosition;
    int maxAttempts = 10;
    int attempts = 0;

    do
    {
        Vector2 halfArea = spawnArea * 0.5f;

        Vector2 randomOffset = new Vector2(
            Random.Range(-halfArea.x, halfArea.x),
            Random.Range(-halfArea.y, halfArea.y)
        );

        spawnPosition = (Vector2)transform.position + randomOffset;
        attempts++;

        // Tenta de novo se sobreposição for detectada
        } while (Physics2D.OverlapCircle(spawnPosition, 0.3f) != null && attempts < maxAttempts);

        if (attempts < maxAttempts)
        {
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        // Desenha o retângulo no editor
        Vector3 center = transform.position;
        Vector3 size = new Vector3(spawnArea.x, spawnArea.y, 0);
        Gizmos.DrawWireCube(center, size);
    }

}
