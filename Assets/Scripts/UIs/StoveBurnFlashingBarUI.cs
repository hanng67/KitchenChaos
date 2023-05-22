using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveBurnFlashingBarUI : MonoBehaviour
{
    private const string IS_FALSHING = "IsFlashing";

    [SerializeField] private StoveCounter stoveCounter;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;

        animator.SetBool(IS_FALSHING, false);
    }

    private void StoveCounter_OnProgressChanged(object sender, IHasProgress.ProgressChangedEventArgs e)
    {
        float burnShowProgressAmount = 0.5f;
        bool isFlashing = stoveCounter.IsFried() && e.progressNomalized >= burnShowProgressAmount;

        animator.SetBool(IS_FALSHING, isFlashing);
    }
}
