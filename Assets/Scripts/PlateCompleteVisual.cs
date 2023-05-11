using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct kitchenObjectSO_GameObject
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }

    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<kitchenObjectSO_GameObject> kitchenObjectSOGameObjectList;

    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;

        foreach (kitchenObjectSO_GameObject kitchenObjectSOGameObjec in kitchenObjectSOGameObjectList)
        {
            kitchenObjectSOGameObjec.gameObject.SetActive(false);
        }
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach (kitchenObjectSO_GameObject kitchenObjectSOGameObjec in kitchenObjectSOGameObjectList)
        {
            if (kitchenObjectSOGameObjec.kitchenObjectSO == e.kitchenObjectSO)
            {
                kitchenObjectSOGameObjec.gameObject.SetActive(true);
            }
        }
    }
}
