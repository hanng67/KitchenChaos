using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWarningTimeIsRunningOutUI : MonoBehaviour
{
    [SerializeField] private Transform warningTransform;

    private float gamePlayingTimerRemainningMax = 5f;

    private void Start()
    {
        HideWarningTransform();
    }

    private void Update()
    {
        bool showWarning = GameManager.Instance.GetGamePlayingTimerRemaining() > 0 &&
                           GameManager.Instance.GetGamePlayingTimerRemaining() <= gamePlayingTimerRemainningMax;

        if (GameManager.Instance.IsGamePlaying() && showWarning)
        {
            ShowWarningTransform();
        }
        else
        {
            HideWarningTransform();
        }
    }

    private void ShowWarningTransform()
    {
        warningTransform.gameObject.SetActive(true);
    }

    private void HideWarningTransform()
    {
        warningTransform.gameObject.SetActive(false);
    }
}
