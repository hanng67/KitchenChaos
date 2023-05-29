using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class TestingNetcodeUI : MonoBehaviour
{
    [SerializeField] private Button startHostButton;
    [SerializeField] private Button startClientButton;

    private void Awake()
    {
        startHostButton.onClick.AddListener(() =>
        {
            Debug.Log("Starting Host");
            NetworkManager.Singleton.StartHost();
            Hide();
            GameManager.Instance.TriggerStateCountdownToStart_TestMode();
        });
        startClientButton.onClick.AddListener(() =>
        {
            Debug.Log("Starting Client");
            NetworkManager.Singleton.StartClient();
            Hide();
            GameManager.Instance.TriggerStateCountdownToStart_TestMode();
        });
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}