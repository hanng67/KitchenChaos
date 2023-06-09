using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipesDeliveredText;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        playAgainButton.onClick.AddListener(() =>
        {
            // NetworkManager.Singleton.Shutdown();
            // BaseCounter.ResetStaticData();
            // CuttingCounter.ResetStaticData();
            // TrashCounter.ResetStaticData();
            // Player.ResetStaticData();
            // Loader.Load(Loader.Scene.GameScene);
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.Shutdown();
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;

        Hide();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
        {
            Show();

            recipesDeliveredText.text = DeliveryManager.Instance.GetSuccessfulRecipesAmount().ToString();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
