using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MushroomMania
{
    public class Rumbler : MonoBehaviour
    {
        
        public void StartRumble(float duration)
        {
            StopAllCoroutines();
            StartCoroutine(Rumble(duration));
        }

        private IEnumerator Rumble(float duration)
        {
            if (Gamepad.current != null)
            {
                Gamepad.current.SetMotorSpeeds(1f, 1f);
                yield return new WaitForSeconds(duration);
                Gamepad.current.SetMotorSpeeds(0f, 0f);
            }
        }

        private void OnDisable()
        {
            if (Gamepad.current != null)
                Gamepad.current.SetMotorSpeeds(0f, 0f);
        }

    }
}
