using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }

    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;

    [SerializeField] private KeyBindingUI moveUpKeyBindingUI;
    [SerializeField] private KeyBindingUI moveDownKeyBindingUI;
    [SerializeField] private KeyBindingUI moveLeftKeyBindingUI;
    [SerializeField] private KeyBindingUI moveRightKeyBindingUI;
    [SerializeField] private KeyBindingUI interactKeyBindingUI;
    [SerializeField] private KeyBindingUI interactAlternateKeyBindingUI;
    [SerializeField] private KeyBindingUI pauseKeyBindingUI;

    [SerializeField] private Transform pressToRebindKeyTransform;

    private Action onCloseButtonAction;

    private void Awake()
    {
        Instance = this;

        soundEffectsButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        musicButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        closeButton.onClick.AddListener(() =>
        {
            Hide();
            onCloseButtonAction();
        });

        moveUpKeyBindingUI.AddListenerRebindBinding(() => { RebindBinding(GameInput.Binding.Move_Up); });
        moveDownKeyBindingUI.AddListenerRebindBinding(() => { RebindBinding(GameInput.Binding.Move_Down); });
        moveLeftKeyBindingUI.AddListenerRebindBinding(() => { RebindBinding(GameInput.Binding.Move_Left); });
        moveRightKeyBindingUI.AddListenerRebindBinding(() => { RebindBinding(GameInput.Binding.Move_Right); });
        interactKeyBindingUI.AddListenerRebindBinding(() => { RebindBinding(GameInput.Binding.Interact); });
        interactAlternateKeyBindingUI.AddListenerRebindBinding(() => { RebindBinding(GameInput.Binding.Interact_Alternate); });
        pauseKeyBindingUI.AddListenerRebindBinding(() => { RebindBinding(GameInput.Binding.Pause); });
    }

    private void Start()
    {
        GameManager.Instance.OnGameUnPaused += GameManager_OnGameUnPaused;

        UpdateVisual();

        HidePressToRebindKey();
        Hide();
    }

    private void GameManager_OnGameUnPaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soundEffectsText.text = $"Sound Effects: {Mathf.Round(SoundManager.Instance.GetVolume() * 10f)}";
        musicText.text = $"Music: {Mathf.Round(MusicManager.Instance.GetVolume() * 10f)}";

        moveUpKeyBindingUI.SetBindingText(GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up));
        moveDownKeyBindingUI.SetBindingText(GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down));
        moveLeftKeyBindingUI.SetBindingText(GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left));
        moveRightKeyBindingUI.SetBindingText(GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right));
        interactKeyBindingUI.SetBindingText(GameInput.Instance.GetBindingText(GameInput.Binding.Interact));
        interactAlternateKeyBindingUI.SetBindingText(GameInput.Instance.GetBindingText(GameInput.Binding.Interact_Alternate));
        pauseKeyBindingUI.SetBindingText(GameInput.Instance.GetBindingText(GameInput.Binding.Pause));
    }

    public void Show(Action onCloseButtonAction)
    {
        this.onCloseButtonAction = onCloseButtonAction;

        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void ShowPressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(true);
    }

    private void HidePressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(false);
    }

    private void RebindBinding(GameInput.Binding binding)
    {
        ShowPressToRebindKey();
        GameInput.Instance.RebindBinding(binding, () =>
        {
            HidePressToRebindKey();
            UpdateVisual();
        });
    }
}
