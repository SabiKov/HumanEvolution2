using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Interface implementation of the inventorySystemController,
/// group of related functionalities is implemented in the 
/// inventorySystemController.class 
/// </summary>
public interface IInventorySystemController {

    /// <summary>
    /// Get item
    /// </summary>
    /// <returns>get selected item</returns>
    List<GameObject> GetInventoryItems();

    /// <summary>
    /// Add item to the inventory slot
    /// </summary>
    /// <param name="item"></param>
    void AddInventoryItem(GameObject item);

    /// <summary>
    /// Remove item to the inventory slot
    /// </summary>
    void RemoveInventoryItem(int itemIndex);

    /// <summary>
    /// Open and close functionalities of the inventory bag  
    /// </summary>
    void OpenInventory();
    void CloseInventory();
}
