using UnityEngine;

/// <summary>
/// This controller controls the healtBar system, scorePanel system and player data
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour, IPlayerController {

    /// <summary>
    /// Instantiate PlayerModel class
    /// </summary>
    private PlayerModel playerModel;
    private int scoreCarryOn;

    /// <summary>
    /// Instantiate the interfaces
    /// </summary>
    private IInventorySystemController inventorySystem;
    private IHealthBarController healtBarSystem;
    private IScorePanelController scoreSystem;

    /// <summary>
    /// Singleton
    /// </summary>
    public static IPlayerController instance;

    /// <summary>
    /// Create public prefab slot
    /// </summary>
    public GameObject inventoryPanel;
    public GameObject healthPanel;
    public GameObject scorePanel;

    /// <summary>
    /// Initializing before the scene starts
    /// </summary>
    public void Awake()
    {
        instance = this;
        this.Init();
    }

    /// <summary>
    /// Initial the player model
    /// </summary>
    private void Init()
    {
        this.playerModel = new PlayerModel();

        if (this.inventoryPanel != null)
            this.inventorySystem = this.inventoryPanel.GetComponent<IInventorySystemController>();

        if (this.healthPanel != null)
            this.healtBarSystem = this.healthPanel.GetComponent<IHealthBarController>();

        if (this.scorePanel != null)
            this.scoreSystem = this.scorePanel.GetComponent<IScorePanelController>();
    }

    /// <summary>
    /// Handle physics collider 
    /// </summary>
    /// <param name="item">Collider item</param>
    private void OnTriggerEnter(Collider item)
    {
        if(item == null || item.gameObject == null)
            return;

        var itemScript = item.gameObject.GetComponent<AbstractGameItemController>();

        Debug.Log("Player Controller item" + itemScript);
        if (itemScript == null)
            return;

        itemScript.DoItemEffect();
    }

    /// <summary>
    /// Reduce health of the player 
    /// </summary>
    /// <param name="amount"></param>
    public void HitPlayer(int amount)
    {
        if (this.playerModel == null)
            return;

        this.playerModel.Health = (int)Mathf.Clamp(this.playerModel.Health - amount, 0.0f, PlayerModel.MAX_HEALTH);
        this.UpdateHealthBar();
    }

    /// <summary>
    /// Add score value
    /// </summary>
    /// <param name="value"></param>
    public void AddScore(int value)
    {
        if (this.playerModel == null)
            return;

        this.playerModel.Score += value;

        if (scoreSystem != null)
            scoreSystem.UpdateScoreText(this.playerModel.Score);
    }

    public void HealPlayer(int amount)
    {
        if (this.playerModel == null)
            return;

        this.playerModel.Health = (int)Mathf.Clamp(this.playerModel.Health + amount, 0.0f, PlayerModel.MAX_HEALTH);
        this.UpdateHealthBar();
    }

    /// <summary>
    /// Add inventory item
    /// </summary>
    /// <param name="inventoryItem">type of game object item</param>
    public void AddInventoryItem(GameObject inventoryItem)
    {
        if (inventoryItem == null || this.inventorySystem == null)
            return;

        Debug.Log("Player Controller add InventoryItem" + inventoryItem);
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
    /// Chapter is selected load the next level, based on the chapter
    /// 
    /// </summary>
    /// <param name="chapterName"></param>
    public void UseChapter(string chapterName)
    {
        if(string.IsNullOrEmpty(chapterName))
            return;
        Debug.Log("ChapterName: " + chapterName);
        Application.LoadLevel(chapterName);
    }

    /// <summary>
    /// Update Health status of player
    /// </summary>
    private void UpdateHealthBar()
    {
        if (this.healtBarSystem != null)
            this.healtBarSystem.SetHealth(((float)this.playerModel.Health) / ((float)PlayerModel.MAX_HEALTH));
    }

}
