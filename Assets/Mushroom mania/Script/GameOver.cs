using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Button restartButton;

    private void Start()
    {
        Debug.Log("✅ RestartButton Loaded!");

        // Find the button if not assigned in the Inspector
        if (restartButton == null)
        {
            restartButton = GameObject.Find("RestartButton")?.GetComponent<Button>();
            if (restartButton != null)
            {
                Debug.Log("✅ RestartButton Found in Scene!");
            }
            else
            {
                Debug.LogError("❌ RestartButton Not Found in Scene!");
                return;
            }
        }

        // Add click event listener
        restartButton.onClick.AddListener(() =>
        {
            Debug.Log("🟢 Restart Button Click Detected!");
            RestartGame();
        });

        Debug.Log("✅ RestartButton Event Assigned!");
    }

    public void RestartGame()
    {
        Debug.Log("✅ Restart Button Clicked! Reloading Game...");
        SceneManager.LoadScene(1); // Loads scene with build index 1

    }
}
