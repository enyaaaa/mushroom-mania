using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HelloMarioFramework
{
    public class HudControl : MonoBehaviour
    {

        //Components
        [SerializeField]
        private Text coinText;

        //Optimization
        private int prevCoin = 0;
#if UNITY_EDITOR
        //Null check
        void Awake()
        {
            SaveData.NullCheck();
        }
#endif
        //Update star and coin count
        void LateUpdate()
        {
            if (prevCoin != SaveData.save.GetCoins())
            {
                prevCoin = SaveData.save.GetCoins();
                coinText.text = SaveData.save.GetCoins().ToString();
            }
        }
    }
}
