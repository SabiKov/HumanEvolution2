using UnityEngine;

public class InventoryGameItemController : AbstractGameItemController {

    public GameObject InventoryItem;

    protected override void FireItemEffect()
    {
        if (PlayerController.Instance != null && this.InventoryItem != null)
            PlayerController.Instance.AddInventoryItem(InventoryItem);

        base.DoDestroy();
    }
}
