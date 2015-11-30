
public class PlayerModel {

    /// <summary>
    /// Declaration the total health
    /// </summary>
    public const int MAX_HEALTH = 100;

    public const int INI_SCORE = 0;

    /// <summary>
    /// Getter and Setter Score, Health
    /// </summary>
    public int Score { get; set; }
    public int Health { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public PlayerModel()
    {
        this.Health = MAX_HEALTH;
        this.Score = INI_SCORE;
    }

}
