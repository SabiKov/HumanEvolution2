using UnityEngine;
using UnityEngine.UI;

public class ScorePanelController : MonoBehaviour, IScorePanelController
{

    /// <summary>
    ///    Display score on panel 
    /// </summary>
    public Text ScoreText;

    /// <summary>
    /// Implement interface method, the integer value is cast into (string)text
    /// </summary>
    /// <param name="scoreValue">increase the scoreValue</param>
    public void UpdateScoreText(int scoreValue)
    {
        if(this.ScoreText != null)
            this.ScoreText.text = scoreValue.ToString();
    }

}
