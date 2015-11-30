public class ScoreGameItemController : AbstarctGameItemController {

    public int addedScoreValue = 100;

    protected override void FireItemEffect()
    {
        if (PlayerController.Instance != null)
            PlayerController.Instance.AddScore(addedScoreValue); // player method

        base.DoDestroy();
    }
}
