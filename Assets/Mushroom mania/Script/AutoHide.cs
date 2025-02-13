using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MushroomMania
{
    public class AutoHide : MonoBehaviour
    {
        
        [Tooltip("Time to display before hiding")]
        [SerializeField]
        public float autoHideAfter = 1f;

        public void ShowMe()
        {
            gameObject.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(HideMe());
        }

        private IEnumerator HideMe()
        {
            yield return new WaitForSeconds(autoHideAfter);
            gameObject.SetActive(false);
        }

    }
}
