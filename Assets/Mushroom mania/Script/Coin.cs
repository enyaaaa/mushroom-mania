using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloMarioFramework
{
    public class Coin : MonoBehaviour
    {

        //Audio clips
        [SerializeField]
        private AudioClip coinSFX;

        //Collision with player
        private void OnTriggerEnter(Collider collision)
        {
            Player p = collision.transform.GetComponent<Player>();
            if (p != null)
            {
                p.PlaySound(coinSFX);
                SaveData.save.CollectCoin();
                Destroy(gameObject);
            }
        }

    }
}
