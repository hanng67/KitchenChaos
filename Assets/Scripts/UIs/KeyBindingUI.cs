using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyBindingUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bindingText;
    [SerializeField] private Button rebindButton;

    public void SetBindingText(string bindingText)
    {
        this.bindingText.text = bindingText;
    }

    public void AddListenerRebindBinding(Action onClickAction)
    {
        rebindButton.onClick.AddListener(() =>
        {
            onClickAction();
        });
    }

}
