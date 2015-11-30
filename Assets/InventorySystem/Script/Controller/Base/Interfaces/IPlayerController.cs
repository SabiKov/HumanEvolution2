using UnityEngine;
using System.Collections;

public interface IPlayerController {

    void AddInventoryItem(GameObject inventoryItem);
    void RemoveInventoryItem(GameObject inventoryItem);
}
