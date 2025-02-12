using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void LoadScene(string sceneName){
        Debug.Log("sceneloader");
        SceneManager.LoadScene(sceneName);
    }
}
