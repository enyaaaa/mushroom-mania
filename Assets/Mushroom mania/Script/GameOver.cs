using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartGame()
    {
        Debug.Log("✅ Restart Button Clicked! Reloading Game...");
        SceneManager.LoadScene("game"); // Replace with your actual game scene name
    }
}
