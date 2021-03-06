﻿using UnityEngine;

public class HealthItemController : AbstractInventoryItemController {

    /// <summary>
    /// Declare the healing value of the inventory health item
    /// </summary>
    [Header("Healing Settings")]
    public int healingValue = 20;


    /// <summary>
    /// override OnInventoryItemClicked() which is located AbstractInventoryItemController class
    /// </summary>
    protected override void OnInventoryItemClicked()
    {
        base.OnInventoryItemClicked();
        this.ChangePlayerHealth();

    }

    /// <summary>
    /// Increase player's health level, then destroy the item
    /// </summary>
    private void ChangePlayerHealth()
    {
        if (PlayerController.instance == null)
            return;

        PlayerController.instance.HealPlayer(healingValue);

        base.DoDestory();
    }
}
