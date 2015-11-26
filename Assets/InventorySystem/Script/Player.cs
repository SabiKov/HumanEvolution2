using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    /// <summary>
    /// Initialize inventoryBag so the player able to store item into a bag.
    /// </summary>
    public PlayerInventoryGUI inventoryBag;

    /// <summary>
    /// Variables hold the maximum health and the current health
    /// </summary>

    const int MAX_HEALTH = 100;
    private int healthLeft = MAX_HEALTH;
    
    /// <summary>
    /// Get method to return the current health level, and number of lives.
    /// </summary>
  //  public int GetHealthLeft() { return healthLeft; }

    /// <summary>
    /// Method to detect when the player collides with enemy.
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

        /*
        if (tag == "DeadlyDose") {
            livesLeft--;
            MoveStartPosition();
            healthLeft = MAX_HEALTH;
        }
        if (livesLeft == 0 && livesLeft < 20) {
          //  Application.LoadLevel("scene_game_over");
        } 
    } */
    }

    /*
    /// <summary>
    /// Variables hold player's maximum lives and current lives
    /// </summary>
    const int MAX_LIVES = 3;
    private int livesLeft = MAX_LIVES;

    public int GetLivesLeft() { return livesLeft; }

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    private void MoveStartPosition() {
        Vector3 startPosition = new Vector3(143, 1, 57);
        transform.position = startPosition;
    }
    */


    /*
            if (tag == "DeadlyDose") {
                livesLeft--;
                MoveStartPosition();
                healthLeft = MAX_HEALTH;
            }
            if (livesLeft == 0 && livesLeft < 20) {
              //  Application.LoadLevel("scene_game_over");
            } 
        } */

}
