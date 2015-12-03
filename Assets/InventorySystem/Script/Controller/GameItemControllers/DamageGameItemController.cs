public class DamageGameItemController : AbstractGameItemController {

    /// <summary>
    /// Attributes 
    /// </summary>
    public int criticalDamageValue = 30;
    public int normalDamageValue = 20;

    /// <summary>
    /// Overrirde abstract method 
    /// </summary>
    protected override void FireItemEffect()
    {
        if (PlayerController.instance != null)
            PlayerController.instance.HitPlayer((base.gameItemType == GameItemTypes.DEADLY_DAMAGE) ? criticalDamageValue : normalDamageValue);

   //     base.DoDestroy();
    }
}
