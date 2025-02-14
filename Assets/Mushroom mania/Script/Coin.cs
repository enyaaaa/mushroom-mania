using UnityEngine;
using UnityEngine.SceneManagement; // Import Scene Management

namespace MushroomMania
{
    public class Coin : MonoBehaviour
    {
        [SerializeField]
        private AudioClip collectSFX; // Sound effect when collecting the star

        [SerializeField]
        private Material collectedCoin; // Material for collected stars

        [Tooltip("All stars must have a unique name! This is how stars are tracked!")]
        [SerializeField]
        private string coinName;

        [Tooltip("Time delay before transitioning to the win page")]
        [SerializeField]
        private float transitionDelay = 2.0f; // 2 seconds delay

        private bool isCollected = false; // Prevents multiple triggers

        private void Start()
        {
            if (IsCollected())
            {
                SkinnedMeshRenderer coinRenderer = transform.GetChild(0).GetChild(2).GetComponent<SkinnedMeshRenderer>();
                if (coinRenderer != null)
                    coinRenderer.material = collectedCoin;
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
                Debug.Log("🌟 Coin Collected!");

                // Disable star visuals & collision after collection
                GetComponent<Collider>().enabled = false;
                gameObject.SetActive(false);
            }
        }

        public bool IsCollected()
        {
            return SaveData.save.CheckCollection(coinName);
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
