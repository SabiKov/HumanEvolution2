using UnityEngine;
using System.Collections;
/// <summary>
/// The Inventory System is under construction, 
/// thus, it is not the final architecture of the inventory system.
/// The functionalities and layout will be the same, however,
/// the system will receive a new MVC design pattern in the final release version of the game.
/// </summary>
public class PlayerScoreGUI : MonoBehaviour
{

    /// <summary>
    /// Instantiate the player class
    /// </summary>

    const int INI_SCORE = 0;
    int totalScore;
    /**
* Variables hold images of the health bar
*/
    public Texture2D score000;
    public Texture2D score100;
    public Texture2D score200;
    public Texture2D score300;
    public Texture2D score400;
    public Texture2D score500;

    private void OnGUI()
    {
        DisplayScore();
    }

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {

    }

    /**
 *Method displays the current player's health level
 */
    private void DisplayScore()
    {
        //     healthAdd = playerInventoryItem.GetHealthAdd();
        int scoreAdd = Player.GetScore();
        //      Debug.Log("PlayerHealthGUI Deadly damage : " + healthLeft);
        GUI.Box(new Rect(20, 5, 100, 40), ScoreBarImage(scoreAdd));
    }

    /**
* Method returns image of the health bar 
*
*/
    private Texture2D ScoreBarImage(int score)
    {
        if (score == 0) { return score000; }
        else if (score == 10) { return score100; }
        else if (score == 20) { return score200; }
        else if (score == 30) { return score300; }
        else if (score == 40) { return score400; }
        else { return score500; }
    }
}
