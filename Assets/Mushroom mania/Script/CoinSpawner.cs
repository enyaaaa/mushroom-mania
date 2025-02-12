using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Assign the Coin Prefab in Inspector
    public int coinCount = 10;    // Number of coins to spawn
    public Vector3 spawnArea = new Vector3(5, 1, 5); // Adjust area for spawning
    public Transform spawnParent; // Optional: Assign a parent object for better organization

    void Start()
    {
        ResetCoins(); // Ensure coins reset when the game starts
        SpawnCoins();
    }

    void SpawnCoins()
    {
        for (int i = 0; i < coinCount; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                spawnArea.y,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            GameObject newCoin = Instantiate(coinPrefab, randomPosition, Quaternion.identity);

            if (spawnParent != null)
            {
                newCoin.transform.SetParent(spawnParent); // Group spawned coins under a parent
            }
        }
    }

    public void ResetCoins()
    {
        // Remove all existing coins in the scene
        GameObject[] existingCoins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject coin in existingCoins)
        {
            Destroy(coin);
        }
    }
}
