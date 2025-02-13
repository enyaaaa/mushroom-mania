﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloMarioFramework
{
    public class ButtonHandler : MonoBehaviour
    {

        //Game
        private bool active = false;

        public void SetActive(bool a)
        {
            active = a;
        }

        public bool IsActive()
        {
            return active;
        }

    }
}
