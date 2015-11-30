using UnityEngine;
using System.Collections;

public interface IPlayerController {

    void AddInventoryItem(GameObject inventoryItem);
    void RemoveInventoryItem(GameObject inventoryItem);
    
    /// <summary>
    /// Add score  
    /// </summary>
    /// <param name="value">score value is 100 after each item</param>
    void AddScore(int value);
}
