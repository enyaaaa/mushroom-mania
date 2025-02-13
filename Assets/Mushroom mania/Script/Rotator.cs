using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MushroomMania
{
    public class Rotator : MonoBehaviour
    {

        [SerializeField]
        private Vector3 rotationSpeed = Vector3.up;

        void Start()
        {
            rotationSpeed *= 100; //Makes this feel more consistent with speeds used in Mover
        }

        void FixedUpdate()
        {
            transform.Rotate(rotationSpeed * Time.fixedDeltaTime);
        }

    }
}
