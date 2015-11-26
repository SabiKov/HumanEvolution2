using UnityEngine;
using System.Collections;

public class PlayerHealthGUI : MonoBehaviour {

    const int MAX_HEALTH = 100;
    int healthLeft;
    /**
* Variables hold images of the health bar
*/
    public Texture2D healthBar00;
    public Texture2D healthBar20;
    public Texture2D healthBar40;
    public Texture2D healthBar60;
    public Texture2D healthBar80;
    public Texture2D healthBar100;

    private void OnGUI() {
        DisplayHealtLeft();
    }

    /**
 *Method displays the current player's health level
 */
    private void DisplayHealtLeft() {
   //     healthAdd = playerInventoryItem.GetHealthAdd();
        healthLeft = Player.GetHealthLeft();
  //      Debug.Log("PlayerHealthGUI Deadly damage : " + healthLeft);
        GUI.Box(new Rect(305, 5, 200, 40), HealthBarImage(healthLeft));
    }
    
    /**
* Method returns image of the health bar 
*
*/
    private Texture2D HealthBarImage(int health) {
        if (health == 100) { return healthBar100; }
        else if (health == 80) { return healthBar80; }
        else if (health == 60) { return healthBar60; }
        else if (health == 40) { return healthBar40; }
        else if (health == 20) { return healthBar20; }
        else { return healthBar00;}
    }
}
