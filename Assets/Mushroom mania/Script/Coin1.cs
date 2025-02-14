using UnityEngine;

namespace MushroomMania
{
    public class Coin1 : MonoBehaviour
    {
        [SerializeField]
        private AudioClip coinSFX;

        private void OnTriggerEnter(Collider collision)
        {
            Player p = collision.transform.GetComponent<Player>();
            if (p != null)
            {
                p.PlaySound(coinSFX);
                SaveData.save.CollectCoin();

                if (GameManager.instance != null)
                {
                    GameManager.instance.AddCoin();
                }

                Debug.Log("🔥 Coin Collected & Destroyed: " + gameObject.name);
                
                // Ensure coin disappears immediately
                gameObject.SetActive(false); 
                Destroy(gameObject, 0.1f); 
            }
        }
    }
}
