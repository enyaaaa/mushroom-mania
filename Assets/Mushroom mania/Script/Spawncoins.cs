using System.Collections;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    public GameObject coinPrefab; // Assign your coin prefab in the Inspector
    public int coinCount = 10;
    public float spawnDelay = 1f;
    public Vector2 spawnArea = new Vector2(5f, 5f);
    public float spawnHeight = 5f; // Adjust this for visibility

    void Start()
    {
        StartCoroutine(SpawnCoin());
    }

    IEnumerator SpawnCoin()
    {
        for (int i = 0; i < coinCount; i++)
        {
            SpawnSingleCoin(); // Call the correct function
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnSingleCoin() // Renamed to avoid duplicates
    {
        if (coinPrefab == null)
        {
            Debug.LogError("Coin Prefab is missing! Assign it in the Inspector.");
            return;
        }

        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            spawnHeight, // Spawn higher so coins fall
            Random.Range(-spawnArea.y, spawnArea.y)
        );

        GameObject newCoin = Instantiate(coinPrefab, randomPosition, Quaternion.identity);
        Debug.Log("Spawning coin at: " + randomPosition);

        // Ensure the coin has a Rigidbody
        Rigidbody rb = newCoin.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = newCoin.AddComponent<Rigidbody>(); // Add Rigidbody if missing
            rb.useGravity = true;
        }
    }
}