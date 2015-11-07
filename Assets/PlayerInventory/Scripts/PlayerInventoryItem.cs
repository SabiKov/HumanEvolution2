using UnityEngine;
using System.Collections;

public class PlayerInventoryItem : MonoBehaviour {

    /// <summary>
    /// Create two slots for sprites. 
    /// spriteIcon: placeholder for normal sprite of item
    /// spriteHoverEffect: placeholder for highlighting selected icon in the inventory bag 
    /// </summary>
    public Sprite spriteNeutral;
    public Sprite spriteHighlighted;

    private int stockSize = 1;

    /// <summary>
    /// Access "Enumeration" ItemType
    /// </summary>
    public ItemType itemType;

    /// <summary>
    /// Method selects the corresponding item type
    /// </summary>
    public void SelectItemType() {

        if (itemType == ItemType.Health) {
            Debug.Log("I reload 10% of health");
            print("I reload 10% of health");
        }
        else if (itemType == ItemType.Chapter1) {
            Debug.Log("I pick up quest item");
        }
        else if (itemType == ItemType.Chapter2) {
            Debug.Log("I pick up tool");
            print("I pick up tool");
        }
        else if (itemType == ItemType.Chapter3) {

        }
        else if (itemType == ItemType.Tool) {
            Debug.Log("I pick up Mats");
            print("I pick up Mats");
        }
        else if (itemType == ItemType.Material) {
            Debug.Log("I pick up Weapon");
        }
        else if (itemType == ItemType.Badge)
        {
            Debug.Log("I pick up quest item");
        }
        else if (itemType == ItemType.Special)
        {
            Debug.Log("I pick up tool");
            print("I pick up tool");
        }
        else {

        }
    }

    /// <summary>
    /// Enumeration value data type which has a set of named integer constant.
    /// This provides a list of different item type a form of drop down menu on UI. 
    /// </summary>
    public enum ItemType
    {
        None,
        Health,
        Chapter1,
        Chapter2,
        Chapter3,
        Tool,
        Material,
        Badge,
        Special
    };
}
