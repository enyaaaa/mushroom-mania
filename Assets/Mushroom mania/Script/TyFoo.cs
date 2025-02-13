using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MushroomMania
{
    public class TyFoo : MonoBehaviour
    {

        //Components
        private Animator animator;
        private Collider myCollider;

        //Animator hash values
        private static int blowHash = Animator.StringToHash("Blow");

        //Blow particle effect + wind trigger
        [SerializeField]
        private GameObject windEffect;

        //Start delay
        [SerializeField]
        private float delay = 0f;
        
        void Start()
        {
            animator = GetComponent<Animator>();
            myCollider = windEffect.GetComponent<Collider>();
            if (delay > 0) StartCoroutine(DelayBlow());
            else StartCoroutine(BlowLoop());
        }

        private IEnumerator BlowLoop()
        {
            //Wait and blow
            yield return new WaitForSeconds(2f);
            animator.SetBool(blowHash, true);
            myCollider.enabled = false;

            //Start blow animation, then blow adter a bit
            yield return new WaitForSeconds(1f);
            windEffect.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            myCollider.enabled = true;

            //Blow for x seconds, then stop
            yield return new WaitForSeconds(4f);
            windEffect.SetActive(false);
            animator.SetBool(blowHash, false);

            //Restart
            StartCoroutine(BlowLoop());

        }

        private IEnumerator DelayBlow()
        {
            yield return new WaitForSeconds(delay);
            StartCoroutine(BlowLoop());
        }

    }
}
