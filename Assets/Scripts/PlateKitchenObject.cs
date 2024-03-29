using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngredientAddEventArgs> OnIngredientAdded;
    public class OnIngredientAddEventArgs : EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }

    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;

    private List<KitchenObjectSO> kitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        Debug.Log(kitchenObjectSO.objectName);
        if (!validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            // Not a valid ingredient.
            return false;
        }
        if (kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            // Already has this type.
            return false;
        } else
        {
            kitchenObjectSOList.Add(kitchenObjectSO);

            OnIngredientAdded?.Invoke(this, new OnIngredientAddEventArgs
            {
                kitchenObjectSO = kitchenObjectSO
            });

            return true;
        }
        
    }

    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
}
