using UnityEngine;
using UnityEngine.SceneManagement; // Import Scene Management

namespace MushroomMania
{
    public class Star : MonoBehaviour
    {
        [SerializeField]
        private AudioClip collectSFX; // Sound effect when collecting the star

        [SerializeField]
        private Material collectedStar; // Material for collected stars

        [Tooltip("Whether collecting this star ends the level")]
        [SerializeField]
        private bool levelEndStar = true;

        [Tooltip("All stars must have a unique name! This is how stars are tracked!")]
        [SerializeField]
        private string starName;

        [Tooltip("Time delay before transitioning to the win page")]
        [SerializeField]
        private float transitionDelay = 2.0f; // 2 seconds delay

        private bool isCollected = false; // Prevents multiple triggers

        private void Start()
        {
            if (IsCollected())
            {
                SkinnedMeshRenderer starRenderer = transform.GetChild(0).GetChild(2).GetComponent<SkinnedMeshRenderer>();
                if (starRenderer != null)
                    starRenderer.material = collectedStar;
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (isCollected) return; // Prevent duplicate collection

            Player p = collision.transform.GetComponent<Player>();

            if (p != null)
            {
                isCollected = true;
                p.PlaySound(collectSFX);
                p.Victory(levelEndStar);
                Debug.Log("🌟 Star Collected! 🎉 Loading win page in " + transitionDelay + " seconds...");

                // Disable star visuals & collision after collection
                GetComponent<Collider>().enabled = false;
                gameObject.SetActive(false);

                // Load the Win Page after delay
                Invoke("LoadWinPage", transitionDelay);
            }
        }

        private void LoadWinPage()
        {
            if (SceneExists("win page")) // Ensure scene name is correct
            {
                Debug.Log("✅ Loading Win Page...");
                SceneManager.LoadScene("win page"); // Load Win Page scene
            }
            else
            {
                Debug.LogError("❌ WinPage scene is not in Build Settings or does not exist!");
            }
        }

        public bool IsCollected()
        {
            return SaveData.save.CheckCollection(starName);
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
}
