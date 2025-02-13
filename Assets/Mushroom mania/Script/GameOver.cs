using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Button restartButton;
    private string gameSceneName = "game"; // Ensure this matches the actual scene name

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

        // Load game scene by name instead of build index
        if (SceneExists(gameSceneName))
        {
            SceneManager.LoadScene(gameSceneName);
        }
        else
        {
            Debug.LogError($"❌ Scene '{gameSceneName}' is not in Build Settings or does not exist!");
        }
    }

    private bool SceneExists(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            if (scenePath.Contains(sceneName))
            {
                return true;
            }
        }
        return false;
    }
}
