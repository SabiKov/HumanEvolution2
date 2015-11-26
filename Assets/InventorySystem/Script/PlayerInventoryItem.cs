using UnityEngine;
using System.Collections;
using System;

public class PlayerInventoryItem : MonoBehaviour {

    /// <summary>
    /// Create two slots for sprites. 
    /// spriteIcon: placeholder for normal sprite of item
    /// </summary>
    public Sprite spriteNeutral;
    public Sprite spriteHighlighted;
    public int stockSize = 1;

    private int RELOAD_HEALTH = 20;
    const int ADD_SCORE = 10;

    private Player player;

    private int healthLeft;
    private int totalScore;

    void Start() {

         player = GetComponent<Player>();
    }

    /// <summary>
    /// Access "Enumeration" ItemType
    /// </summary>
    public ItemType itemType;


    /// <summary>
    /// Method selects the corresponding item type
    /// </summary>
    public void SelectItemType() {

        if (itemType == ItemType.Health) {
            healthLeft = Player.GetHealthLeft();
            if (healthLeft <= 80) {
                Player.UsedHealthPack(RELOAD_HEALTH);
                Debug.Log("I reload +20% of health ");
            }
            else {
                Debug.Log("Health is on 100% ");
            }
        }
        else if (itemType == ItemType.Chapter1) {
            Debug.Log("I pick up PAGE/BOOK item");
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
        else if (itemType == ItemType.Badge) {
            Debug.Log("I pick up BADGE item");
            Player.UsedScore(ADD_SCORE);
        }
        else if (itemType == ItemType.Special) {
            Debug.Log("I pick up tool");
            print("I pick up tool");
        }
        else { }
    }

    /// <summary>
    /// Enumeration value data type which has a set of named integer constant.
    /// This provides a list of different item type a form of drop down menu on UI. 
    /// </summary>
    public enum ItemType {
        Health,
        Chapter1,
        Chapter2,
        Chapter3,
        Tool,
        Material,
        Badge,
        Special
    };

    public static void Reload20PerCentHealth() {

    }

}
