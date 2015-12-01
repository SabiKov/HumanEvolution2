public class DamageGameItemController : AbstractGameItemController {

    #region Properties

    public int CriticalDamageValue = 30;
    public int NormalDamageValue = 20;

    #endregion

    protected override void FireItemEffect()
    {
        if (PlayerController.Instance != null)
            PlayerController.Instance.HitPlayer((base.GameItemType == GameItemTypes.DEADLY_DAMAGE) ? CriticalDamageValue : NormalDamageValue);

        base.DoDestroy();
    }
}
