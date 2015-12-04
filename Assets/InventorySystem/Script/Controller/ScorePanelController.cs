using UnityEngine;
using UnityEngine.UI;

public class ScorePanelController : MonoBehaviour, IScorePanelController
{

    private const string PERCENTAGE_SIGN = " %";

    /// <summary>
    ///    Display score on panel 
    /// </summary>
    public Text scoreText;



    /// <summary>
    /// Implement interface method, the integer value is cast into (string)text
    /// </summary>
    /// <param name="scoreValue">increase the scoreValue</param>
    public void UpdateScoreText(int scoreValue)
    {
        if (this.scoreText != null) {
                this.scoreText.text = scoreValue.ToString() + PERCENTAGE_SIGN;

        }
    }

}
