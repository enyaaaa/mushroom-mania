﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MushroomMania
{
    public class LoadingScreen : MonoBehaviour
    {
        private static AsyncOperation asyncLoad;

        //Next scene to load
        public static string scene;

        //Remember hub scene information
        public static string titleScene;
        public static string hubScene;

        // Use this for initialization
        void Start()
        {
            StartCoroutine(LoadAsyncScene());
        }

        private IEnumerator LoadAsyncScene()
        {
            //Load the scene from the variable
#if UNITY_EDITOR
            if (scene == null)
            {
                Debug.Log("Mushroom Mania: Hub scene not set. Returning to title screen! (The hub scene will be set if you start the game from the title screen)");
                asyncLoad = SceneManager.LoadSceneAsync(0);
            }
            else
#endif
                asyncLoad = SceneManager.LoadSceneAsync(scene);

            //Fade Control (Wait for fadeout)
            asyncLoad.allowSceneActivation = false;
            yield return new WaitForSeconds(0.5f);
            asyncLoad.allowSceneActivation = true;
        }

        public static bool IsHubScene()
        {
            return (SceneManager.GetActiveScene().path == hubScene);
        }
    }
}
