
public class PlayerModel {

    #region Properties

    #region Constants

    public const int MAX_HEALTH = 100;

    #endregion

    public int Health { get; set; }
    public int Score { get; set; }

    #endregion

    public PlayerModel()
    {
        this.Health = MAX_HEALTH;
        this.Score = 0;
    }

}
