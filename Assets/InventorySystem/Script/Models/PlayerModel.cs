
public class PlayerModel {

    public const int MAX_HEALTH = 100;



    /// <summary>
    /// Constructor signs the initial values of health and score 
    /// </summary>
    public PlayerModel()
    {
       this.Health = MAX_HEALTH;
       this.Score = 0;
    }

    /// <summary>
    /// Get and Set modifiers 
    /// </summary>
    public int Health { get; set; }
    public int Score { get; set; }

}
