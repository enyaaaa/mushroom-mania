using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Assign the Coin Prefab in Inspector
    public int coinCount = 10;    // Number of coins to spawn
    public Vector3 spawnArea = new Vector3(5, 1, 5); // Adjust area for spawning

    void Start()
    {
        SpawnCoins();
    }

    void SpawnCoins()
    {
        for (int i = 0; i < coinCount; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x, spawnArea.x), 
                spawnArea.y, 
                Random.Range(-spawnArea.z, spawnArea.z)
            );

            Instantiate(coinPrefab, randomPosition, Quaternion.identity);
        }
    }
}