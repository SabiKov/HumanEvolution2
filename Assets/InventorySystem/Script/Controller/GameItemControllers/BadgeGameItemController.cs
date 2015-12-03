public class BadgeGameItemController : AbstractGameItemController
{

    /// <summary>
    /// Value of the star
    /// </summary>
    public int addedScoreValue = 20;

    protected override void FireItemEffect()
    {
        if (PlayerController.instance != null)
            PlayerController.instance.AddScore(addedScoreValue);

        base.DoDestroy();
    }

}
