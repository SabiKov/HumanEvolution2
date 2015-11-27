using UnityEngine;
using System.Collections;

public interface IPlayerControl {

    void AddInventoryItem(GameObject inventoryItem);
    void RemoveInventoryItem(GameObject inventoryItem);

}
