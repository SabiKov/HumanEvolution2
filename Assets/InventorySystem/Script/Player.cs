using UnityEngine;
using System.Collections;

/// <summary>
/// The Inventory System is under construction, 
/// thus, it is not the final architecture of the inventory system.
/// The functionalities and layout will be the same, however,
/// the system will receive a new MVC design pattern in the final release version of the game.
/// </summary>
public class Player : MonoBehaviour {


    /// <summary>
    /// Initialize inventoryBag so the player able to store item into a bag.
    /// </summary>
    public PlayerInventoryGUI inventoryBag;

    private PlayerInventoryItem playerInventoryItem;
    
    /// <summary>
    /// Variables hold the maximum health and the current health
    /// </summary>

    const int MAX_HEALTH = 100;
    private static int healthLeft = MAX_HEALTH;

    const int INI_SCORE = 0;
    private static int scoreAdd = INI_SCORE;

    /// <summary>
    /// Get method to return the current health level.
    /// </summary>
    public static int GetHealthLeft() { return healthLeft; }

    /// <summary>
    /// Get method to return the current score value.
    /// </summary>
    public static int GetScore() { return scoreAdd; }

    /// <summary>
    /// If the player is hit the player's health will be reduced. 
    /// When the health level is equals zero one lives will be reduced.
    /// If the lives is equals zero the game over scene will be loaded.
    /// </summary>
    private void OnTriggerEnter(Collider item) {

        string tag = item.tag;

        /// tag need to be added to each item which can be placed into inventory system
        if (tag == "InventoryItem") {
           inventoryBag.AddItem(item.GetComponent<PlayerInventoryItem>());
        }

        if (tag == "DeadlyDamage") {
            
            healthLeft -= 20;
            Debug.Log("Player class Deadly damage : " + healthLeft);
            //          GetHealthLeft();
            Destroy(item.gameObject);
        }
        if (tag == "SmallDamage") {

            healthLeft -= 20;
            Destroy(item.gameObject);
        }

        if (tag == "InventoryItem") {
            Destroy(item.gameObject);
        }
    }

    /// <summary>
    /// This method is responsible for increase an health level 
    /// when health bar is selected in the inventory. Since the method is public static therefore
    /// can be accessed by any classes  
    /// </summary>
    /// <param name="addHealth"></param>
    public static void UsedHealthPack(int addHealth) {
        if (healthLeft < MAX_HEALTH) {
            healthLeft += addHealth;
        }
    }

    /// <summary>
    /// This method is responsible for increase an health level 
    /// when health bar is selected in the inventory. Since the method is public static therefore
    /// can be accessed by any classes  
    /// </summary>
    /// <param name="addScore"></param>
    public static void UsedScore(int addScore) {

        scoreAdd += addScore;
  
    }
}
