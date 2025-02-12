using UnityEngine;
using UnityEngine.UI;

public class ButtonDebug : MonoBehaviour
{
    void Start()
    {
        Debug.Log("✅ Restart Button Loaded!");
        GetComponent<Button>().onClick.AddListener(() => Debug.Log("✅ Restart Button Clicked!"));
    }
}
