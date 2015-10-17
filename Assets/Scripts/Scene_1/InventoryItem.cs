using UnityEngine;
using System.Collections;

[System.Serializable]
public class InventoryItems {

   // public InventoryDB inventoryDB;


    /// <summary>
    /// Attributes 
    /// public variables provide a customizable 
    /// </summary>
    public string name;
    public string id;
    public string healthPoint;
    public string description;
    public int value;
    public Texture2D image;

    public ItemType itemType;
    internal object itemName;

    /// <summary>
    /// Creating a set of static object 
    /// </summary>
    public enum ItemType {
        Tool,
        Usable,
        QuestItem,
        Weapon,
        Consumable   
    }
}
