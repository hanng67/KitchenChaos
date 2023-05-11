using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private Transform iconTemplate;

    private void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        UpdateVisual(e);
    }

    private void UpdateVisual(PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        Transform iconTransform = Instantiate(iconTemplate, transform);
        iconTransform.gameObject.SetActive(true);
        iconTransform.GetComponent<PlateIconSingleUI>().SetKitchenObjectSO(e.kitchenObjectSO);
    }
}
