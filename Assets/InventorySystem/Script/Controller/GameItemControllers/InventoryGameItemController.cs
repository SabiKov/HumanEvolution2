using UnityEngine;

public class InventoryGameItemController : AbstractGameItemController {

    public GameObject inventoryItem;

    protected override void FireItemEffect()
    {
        if (PlayerController.instance != null && this.inventoryItem != null)
            PlayerController.instance.AddInventoryItem(inventoryItem);

        base.DoDestroy();
    }
}
