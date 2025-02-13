using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloMarioFramework
{
    public class TransformSwapper : MonoBehaviour
    {
        //Transforms
        public GameObject[] listObjs;

        //Swap between different gameobjects
        public void Change(int index)
        {
            for (int i = 0; i < listObjs.Length; i++)
            {
                listObjs[i].SetActive(i == index);
            }
        }

    }
}
