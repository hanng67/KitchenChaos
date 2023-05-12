using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private Image barImage;

    private IHasProgress hasProgress;

    private void Start()
    {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();
        if (hasProgress == null)
        {
            Debug.LogError("Game Object" + hasProgressGameObject + "does not have a component that implements IHasProgress!");
        }

        hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;
        
        barImage.fillAmount = 0;
        Hide();
    }

    private void HasProgress_OnProgressChanged(object sender, IHasProgress.ProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNomalized;

        if (e.progressNomalized == 0 || e.progressNomalized == 1)
        {
            Hide();
        }
        else
        {
            Show();
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
