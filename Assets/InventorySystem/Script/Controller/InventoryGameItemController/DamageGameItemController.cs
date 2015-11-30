using UnityEngine;
using System.Collections;

public class DamageGameItemController : AbstarctGameItemController {

    public int criticalDamageValue = 30;
    public int normalDamageValue = 20;


    protected override void FireItemEffect()
    {
        if (PlayerController.Instance != null)
            PlayerController.Instance.HitPlayer((base.GameItemType == GameItemTypes.DEADLY_DAMAGE) ? criticalDamageValue : normalDamageValue);

        base.DoDestroy();
    }
}
