using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloMarioFramework
{
    public class SpikeSpawn : MonoBehaviour
    {

        //Components
        private Rigidbody myRigidBody;

        //Game
        private bool grow = true;
        private bool full = false;
        
        void Start()
        {
            myRigidBody = GetComponent<Rigidbody>();
            myRigidBody.isKinematic = true;
            transform.localScale = Vector3.zero;
        }
        
        void FixedUpdate()
        {

            //Grow
            if (grow)
            {
                if (!full)
                {
                    transform.localScale += Vector3.one * 1f * Time.fixedDeltaTime;// 0.02f;
                    transform.position += Vector3.up * 2f * Time.fixedDeltaTime;// 0.04f;
                    if (transform.localScale.y >= 1)
                    {
                        full = true;
                        transform.localScale = Vector3.one;
                        StartCoroutine(Throw());
                    }
                }
            }

            //Shrink
            else
            {
                transform.localScale -= Vector3.one * 1f * Time.fixedDeltaTime;// 0.02f;
                if (transform.localScale.y <= 0) Destroy(gameObject);
            }

        }

        private IEnumerator Throw()
        {
            //Throw
            yield return new WaitForSeconds(1.8f);
            myRigidBody.isKinematic = false;
            myRigidBody.linearVelocity = (transform.forward + Vector3.up) * 4f;


            //Despawn
            yield return new WaitForSeconds(14f);
            grow = false;

        }

    }
}
