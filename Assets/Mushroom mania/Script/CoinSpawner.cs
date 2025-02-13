using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Assign Coin Prefab
    public int coinCount = 10;    // Number of coins to spawn
    public Vector3 spawnArea = new Vector3(5, 1, 5); // Spawn area size

    void Start()
    {
        ResetCoins(); // Ensure old coins are removed before spawning new ones
        SpawnCoins();
    }

    void ResetCoins()
    {
        GameObject[] existingCoins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject coin in existingCoins)
        {
            Destroy(coin);
        }
        Debug.Log("✅ All old coins removed!");
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
        Debug.Log("✅ Coins Spawned!");
    }
}
