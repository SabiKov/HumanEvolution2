using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// This is a player controller such as player's data
/// </summary>
public class PlayerController : MonoBehaviour, IPlayerController {

    /// <summary>
    /// Instantiate PlayerModel class
    /// </summary>
    private PlayerModel playerModel;

    /// <summary>
    /// Instantiate the interfaces
    /// </summary>
    private IInventorySystemController inventorySystem;
    private IScorePanelController scoreSystem;

    /// <summary>
    /// Create public prefab slot
    /// </summary>
    public GameObject inventoryPanel;
    public GameObject ScorePanel;

    /// <summary>
    /// Singleton
    /// </summary>
    public static IPlayerController Instance;

    /// <summary>
    /// Initializing before the scene starts
    /// </summary>
    public void Awake()
    {
        Instance = this;
        this.Init();
    }

    /// <summary>
    /// 
    /// </summary>
    private void Init()
    {
        this.playerModel = new PlayerModel();

        if (this.inventoryPanel != null)
            this.inventorySystem = this.inventoryPanel.GetComponent<IInventorySystemController>();

        if (this.ScorePanel != null)
            this.scoreSystem = this.ScorePanel.GetComponent<IScorePanelController>();
    }

    /// <summary>
    /// Handle physics collider 
    /// </summary>
    /// <param name="item">Collider item</param>
    private void OnTriggerEnter(Collider item)
   {
       if (item == null || item.gameObject == null)
           return;

       var itemScript = item.gameObject.GetComponent<AbstarctGameItemController>();
       if (itemScript == null)
           return;

       itemScript.DoItemEffect();
   }

    /// <summary>
    /// Add inventory item
    /// </summary>
    /// <param name="inventoryItem">type of game object item</param>
    public void AddInventoryItem(GameObject inventoryItem)
    {
       if (inventoryItem == null || this.inventorySystem == null)
           return;

       this.inventorySystem.AddInventoryItem(inventoryItem);
    }

    /// <summary>
    /// Remove item from slot
    /// </summary>
    /// <param name="inventoryItem">type of object item</param>
    public void RemoveInventoryItem(GameObject inventoryItem)
    {
       if (inventoryItem == null || this.inventorySystem == null)
           return;

       var itemScript = inventoryItem.GetComponent<AbstractInventoryItemController>();
       if (itemScript == null)
           return;

       this.inventorySystem.RemoveInventoryItem(itemScript.ItemIndex);
    }

    /// <summary>
    /// Add score value
    /// </summary>
    /// <param name="value"></param>
    public void AddScore(int value)
    {
        Debug.Log("1 PalyerController" + value.ToString());
        if (this.playerModel == null)
            return;

        this.playerModel.Score += value;

        Debug.Log("2 PalyerController" + value.ToString());

        //Update Text in score Panel
        if (scoreSystem != null)
            scoreSystem.UpdateScoreText(this.playerModel.Score); // update score

        Debug.Log("3 PalyerController" + this.playerModel.Score);
    }
}
