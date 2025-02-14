using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // For UI Text
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;  // Singleton pattern
    private int coinCount = 0;  // Track collected coins
    private Text coinText; // Reference to the UI text displaying the coin count

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object when loading scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Find the CoinCount UI Text automatically if not set
        coinText = GameObject.Find("CoinCount")?.GetComponent<Text>();
        if (coinText == null)
        {
            Debug.LogWarning("⚠️ CoinCount UI Text not found! Make sure the GameObject name is correct.");
        }

        UpdateCoinUI();
    }

    public void AddCoin()
    {
        coinCount++;
        Debug.Log("Coins Collected: " + coinCount);
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount;
        }
    }

    public void PlayerDied()
    {
        Debug.Log("Player has died! Loading Game Over Page...");
        Invoke("LoadGameOverPage", 2f);
    }

    private IEnumerator LoadGameOverPageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("gameover page");
    }

    private void LoadGameOverPage()
    {
        SceneManager.LoadScene("gameover page");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("game");
    }
}
