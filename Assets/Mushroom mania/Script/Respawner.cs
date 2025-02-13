﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MushroomMania
{
    public class Respawner : MonoBehaviour
    {

        //Original position
        private Vector3 pos;
        private Quaternion rot;
        private Vector3 sca;

        //Thing to respawn
        [SerializeField]
        private GameObject respawn;

        // Start is called before the first frame update
        void Start()
        {
            pos = transform.position;
            rot = transform.localRotation;
            sca = transform.localScale;
        }

        public void RespawnThis()
        {
            Transform obj = Instantiate(respawn).transform;
            obj.position = pos;
            obj.localRotation = rot;
            obj.localScale = sca;
        }
    }
}
