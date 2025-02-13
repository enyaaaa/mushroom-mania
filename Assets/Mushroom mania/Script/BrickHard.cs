using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloMarioFramework
{
    public class BrickHard : MonoBehaviour
    {

        [SerializeField]
        private GameObject breakAnimation;

        public void BreakBrick()
        {
            GameObject o = Instantiate(breakAnimation);
            o.transform.position = transform.position;
            o.transform.rotation = transform.rotation;
            o.transform.localScale = transform.localScale;
            Destroy(gameObject);
        }

    }
}
