using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloMarioFramework
{
    public class Propeller : MonoBehaviour
    {

        //Components
        private AudioSource audioPlayer;

        //Jump height
        [SerializeField]
        public Vector3 propellerJumpVector = new Vector3(0f, 18f, 0f);

        //Audio clips
        [SerializeField]
        private AudioClip propellerSFX;

        //Game
        private bool rotateNow = false;

        void Start()
        {
            audioPlayer = gameObject.AddComponent<AudioSource>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (rotateNow) transform.Rotate(Vector3.up * 2000f * Time.fixedDeltaTime);
        }

        public void Rotate()
        {
            audioPlayer.PlayOneShot(propellerSFX);
            StartCoroutine(RotateTimer());
        }

        private IEnumerator RotateTimer()
        {
            rotateNow = true;
            yield return new WaitForSeconds(1f);
            rotateNow = false;
        }

    }
}
