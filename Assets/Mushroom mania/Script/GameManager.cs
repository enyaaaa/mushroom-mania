using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene loading

public class GameManager : MonoBehaviour
{
    public static GameManager instance;  // Singleton pattern
    private int coinCount = 0;  // Track collected coins

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
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

    // Function to add a coin
    public void AddCoin()
    {
        coinCount++;
        Debug.Log("Coins Collected: " + coinCount);
    }

    // Function to reset coin count when game restarts
    public void ResetCoinCount()
    {
        coinCount = 0;
        Debug.Log("Coin count reset!");
    }

    // Call this function when the player dies
    public void PlayerDied()
    {
        Debug.Log("Player has died! Loading Game Over Page...");
        Invoke("LoadGameOverPage", 2f); // Delay restart for 2 seconds
    }

    private void LoadGameOverPage()
    {
        SceneManager.LoadScene("gameover page");
    }

    // Function to restart the game and reset coins
    public void RestartGame()
    {
        ResetCoinCount();  // Reset coin count on game restart
        SceneManager.LoadScene("game");
    }
}
