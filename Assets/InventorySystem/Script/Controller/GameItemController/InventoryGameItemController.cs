using UnityEngine;
using System.Collections;

public class InventoryGameItemController : AbstarctGameItemController {


    public GameObject InventoryItem;


    protected override void FireItemEffect()
    {
        if (PlayerController.Instance != null && this.InventoryItem != null)
            PlayerController.Instance.AddInventoryItem(InventoryItem);

        base.DoDestroy();
    }
}
