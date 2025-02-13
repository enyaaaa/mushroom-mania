using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MushroomMania
{
    public class CoinColor : MonoBehaviour
    {

        //Color
        public enum Color { Red, Purple, None };
        [SerializeField]
        private Color color;

        //Audio clips
        [SerializeField]
        private AudioClip coinSFX;

        //Coin text animation
        [SerializeField]
        private GameObject coinAnimObj;

        //Spawner tracking this coin
        private StarSpawnerCoin starSpawner = null;

        //Collision with player
        private void OnTriggerEnter(Collider collision)
        {
            Player p = collision.transform.GetComponent<Player>();
            if (p != null)
            {
                p.PlaySound(coinSFX);
                if (starSpawner != null)
                {
                    GameObject o = Instantiate(coinAnimObj);
                    o.transform.position = transform.position;
                    o.GetComponentInChildren<Text>().text = starSpawner.Notify().ToString();
                }
                Destroy(gameObject);
            }
        }

        public bool Track(StarSpawnerCoin tracker, Color col)
        {
            if (col == color)
            {
                starSpawner = tracker;
                return true;
            }
            else return false;
        }

    }
}
