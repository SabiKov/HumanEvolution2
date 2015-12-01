using UnityEngine;

public interface IPlayerController {

    void AddInventoryItem(GameObject inventoryItem);
    void RemoveInventoryItem(GameObject inventoryItem);

    /// <summary>
    /// Add score, used in the scoreItemContorller
    /// </summary>
    /// <param name="value">score value is 100 after each item</param>
    void AddScore(int value);

    /// <summary>
    /// Increase healing level by 20%
    /// </summary>
    /// <param name="healingValue">healing value is constant 20</param>
    void HealPlayer(int amount);

    /// <summary>
    /// Decrease player's health by 20%
    /// </summary>
    /// <param name="healingValue">damage value</param>
    void HitPlayer(int amount);

    /// <summary>
    /// Load next scene
    /// </summary>
    /// <param name="healingValue">chapter name aka scene's name</param>
    void UseChapter(string chapterName);
}
