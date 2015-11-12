using UnityEngine;
using System.Collections;

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
    private int healthLeft = MAX_HEALTH;
    
    /// <summary>
    /// Get method to return the current health level, and number of lives.
    /// </summary>
    public int GetHealthLeft() { return healthLeft; }
    
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
        }
        if (tag == "SmallDamage") {

            healthLeft -= 20;
            Debug.Log("Player class Deadly damage : " + healthLeft);
 //           GetHealthLeft();
        }
    }

    public void UsedHealthPack(int health) {

        Debug.Log("Player class healthUp : " + health);
        int healthUp = health;
        healthLeft += healthUp;
    }
}
