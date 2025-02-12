using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene loading

public class GameManager : MonoBehaviour
{
    public static GameManager instance;  // Singleton pattern

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

    // Call this function when the player dies
    public void PlayerDied()
    {
        Debug.Log("Player has died! Loading Game Over Page...");
        Invoke("LoadGameOverPage", 2f); // Delay restart for 2 seconds
    }

    private void LoadGameOverPage()
    {
        SceneManager.LoadScene("gameover page"); // Make sure your Game Over scene is named "GameOver"
    }
}
