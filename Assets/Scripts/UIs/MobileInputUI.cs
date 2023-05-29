using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInputUI : MonoBehaviour
{
    private void Start()
    {
#if !UNITY_EDITOR || !(UNITY_ANDROID || UNITY_IOS)
        gameObject.SetActive(Application.isMobilePlatform);
#endif
    }
}
