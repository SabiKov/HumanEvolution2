public class BadgeGameItemController : AbstractGameItemController
{

    /// <summary>
    /// Value of the star
    /// </summary>
    public int AddedScoreValue = 20;

    protected override void FireItemEffect()
    {
        if (PlayerController.Instance != null)
            PlayerController.Instance.AddScore(AddedScoreValue);

        base.DoDestroy();
    }

}
