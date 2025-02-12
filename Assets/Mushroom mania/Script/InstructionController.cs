using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionController : MonoBehaviour
{
    public Button startButton; // Assign this in the Inspector

    private void Start()
    {
        Debug.Log("✅ StartButton Loaded!");

        // Find the button if not assigned in the Inspector
        if (startButton == null)
        {
            startButton = GameObject.Find("StartButton")?.GetComponent<Button>();
            if (startButton != null)
            {
                Debug.Log("✅ StartButton Found in Scene!");
            }
            else
            {
                Debug.LogError("❌ StartButton Not Found in Scene!");
                return;
            }
        }

        // Add click event listener
        startButton.onClick.AddListener(() =>
        {
            Debug.Log("🟢 Start Button Click Detected!");
            LoadGame();
        });

        Debug.Log("✅ StartButton Event Assigned!");
    }

    public void LoadGame()
    {
        Debug.Log("✅ Loading Game Scene...");
        SceneManager.LoadScene(2); // Make sure "game" is in Build Settings
    }
    public void TestClick()
    {
        Debug.Log("🔥 Button Clicked!");
    }

}
