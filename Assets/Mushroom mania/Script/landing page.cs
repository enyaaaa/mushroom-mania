using UnityEngine;
using UnityEngine.SceneManagement; // Import Scene Management

public class MainMenu : MonoBehaviour
{
    public void LoadInstructions()
    {
        Debug.Log("📜 Loading Instructions Page...");
        SceneManager.LoadScene("instruction"); // Make sure "Instructions" is the correct scene name
    }
}
