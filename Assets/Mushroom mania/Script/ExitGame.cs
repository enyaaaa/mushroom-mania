using UnityEngine;
using UnityEngine.SceneManagement; // For scene switching

public class ExitGame : MonoBehaviour
{
    public void ExitToMainMenu()
    {
        Debug.Log("🏠 Returning to Main Menu...");
        SceneManager.LoadScene("landing page"); // Change to the correct name of your main menu scene
    }
}
