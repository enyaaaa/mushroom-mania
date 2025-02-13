using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MushroomMania
{
    public class Coin : MonoBehaviour
    {
        [SerializeField]
        private AudioClip coinSFX;

        private void OnTriggerEnter(Collider collision)
        {
            Player p = collision.transform.GetComponent<Player>();
            if (p != null)
            {
                p.PlaySound(coinSFX);
                SaveData.save.CollectCoin(); // Existing coin collection method

                // Update GameManager's coin count
                if (GameManager.instance != null)
                {
                    GameManager.instance.AddCoin();
                }

                Destroy(gameObject);
            }
        }
    }
}
