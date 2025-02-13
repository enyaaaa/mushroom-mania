using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloMarioFramework
{
    public class Enemy : Stompable
    {

        //Components
        private Rigidbody myRigidBody;
        protected Animator animator;
        private AudioSource audioPlayer;
        private Collider myCollider;

        //Audio clips
        [SerializeField]
        protected AudioClip voiceSFX;

        //Game
        protected bool chase = false;
        protected bool cooldown = false;
        private bool onGround = true;
        private int collisionCount = 0;

        //Animator hash values
        protected static int chaseHash = Animator.StringToHash("Chase");
        private static int stompHash = Animator.StringToHash("Stomp");
        private static int speedHash = Animator.StringToHash("Speed");
        private static int groundHash = Animator.StringToHash("onGround");

        //Stompable
        [SerializeField]
        protected bool stompable = true;
        
        void Start()
        {
            myRigidBody = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            audioPlayer = gameObject.AddComponent<AudioSource>();
            myCollider = GetComponent<Collider>();

            myRigidBody.freezeRotation = true;
            if (!stompable) stompHeightCheck = 100f;
        }

        //Before draw calls
        private void LateUpdate()
        {
            if (chase)
            {
                Vector3 i = new Vector3(myRigidBody.linearVelocity.x, 0f, myRigidBody.linearVelocity.z);
                animator.SetFloat(speedHash, i.magnitude);
            }
        }

        //What to do when stomped. Override this.
        protected override void WhenStomped()
        {
            chase = false;
            cooldown = true;
            animator.SetBool(stompHash, true);
            myCollider.enabled = false;
            myRigidBody.isKinematic = true;
            myRigidBody.detectCollisions = false;
        }

        //What to do when hurting player. Override this.
        protected override void WhenHurtPlayer(Player p)
        {
            chase = false;
            myRigidBody.linearVelocity = Vector3.zero;
            StopAllCoroutines();
            if (p.GetHealth() > 0)
                StartCoroutine(Cooldown(1.1f));
            else
            {
                animator.SetBool(chaseHash, false);
                cooldown = true;
            }
        }

        //Move fixed update to here. Override this.
        protected override void FixedUpdateStompable()
        {
            myRigidBody.rotation = Quaternion.Euler(0f, myRigidBody.rotation.eulerAngles.y, 0f);

            //Collision delay
            if (collisionCount > 0)
            {
                collisionCount--;
                if (collisionCount == 0)
                {
                    onGround = false;
                    animator.SetBool(groundHash, false);
                }
            }

            //Manage drag
            if (!onGround) myRigidBody.linearDamping = 0f;
            else if (chase) myRigidBody.linearDamping = 1.7f;
            else myRigidBody.linearDamping = 100f;

            //Cooldown
            if (!cooldown)
            {
                //Start chase
                if (onGround && !chase && Player.singleton.CanBeChased(transform.position, 10f))
                {
                    chase = true;
                    StartCoroutine(Cooldown(0.9f));
                    audioPlayer.PlayOneShot(voiceSFX);
                }

                //End chase
                else if (!onGround || (chase && !Player.singleton.CanBeChased(transform.position, 10f)))
                {
                    chase = false;
                    StartCoroutine(Cooldown(1.1f));
                    if (onGround) myRigidBody.linearVelocity = Vector3.zero;
                }

                //Chase
                if (chase)
                {
                    //Change direction
                    Player.singleton.LookAtMe(transform);

                    //Move in direction
                    myRigidBody.linearVelocity += transform.forward * 12.5f * Time.fixedDeltaTime; //0.25f

                    //Speed cap
                    Vector2 mvmntSpeed = new Vector2(myRigidBody.linearVelocity.x, myRigidBody.linearVelocity.z);
                    if (mvmntSpeed.sqrMagnitude > 16f)
                    {
                        mvmntSpeed.Normalize();
                        mvmntSpeed = mvmntSpeed * 4f;
                        myRigidBody.linearVelocity = new Vector3(mvmntSpeed.x, myRigidBody.linearVelocity.y, mvmntSpeed.y);
                    }

                }
            }
        }

        //Move on collision stay to here. Override this.
        protected override void OnCollisionStayStompable(Collision collision)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                if (Vector3.Dot(contact.normal, Vector3.up) > 0.6f)
                {
                    if (!onGround)
                    {
                        onGround = true;
                        animator.SetBool(groundHash, true);
                    }
                    collisionCount = 8;
                    break;
                }
            }
        }

        //Cooldown
        private IEnumerator Cooldown(float f)
        {
            animator.SetBool(chaseHash, chase);
            cooldown = true;
            yield return new WaitForSeconds(f); //0.9f
            cooldown = false;
        }

    }
}
