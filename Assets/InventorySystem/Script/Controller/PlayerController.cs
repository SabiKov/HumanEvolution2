using UnityEngine;

/// <summary>
/// This is a player controller such as player's data
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour, IPlayerController {

    /// <summary>
    /// Instantiate PlayerModel class
    /// </summary>
    private PlayerModel playerModel;

    /// <summary>
    /// Instantiate the interfaces
    /// </summary>
    private IInventorySystemController inventorySystem;
    private IScorePanelController scoreBarSystem;
    private IHealthBarController heathBarSystem;

    /// <summary>
    /// Create public prefab slot
    /// </summary>
    public GameObject inventoryPanel;
    public GameObject scorePanel;
    public GameObject healthPanel;

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

        if (this.scorePanel != null)
            this.scoreBarSystem = this.scorePanel.GetComponent<IScorePanelController>();

        if (this.healthPanel != null)
            this.heathBarSystem = this.healthPanel.GetComponent<IHealthBarController>();
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

      //  Debug.Log("2 PalyerController" + value.ToString());

        //Update Text in score Panel
        if (scoreBarSystem != null)
            scoreBarSystem.UpdateScoreText(this.playerModel.Score); // update score

        Debug.Log("3 PalyerController" + this.playerModel.Score);
    }

    public void HitPlayer(int amount)
    {
        if (this.playerModel == null)
            return;

        this.playerModel.Health = (int)Mathf.Clamp(this.playerModel.Health - amount, 0.0f, PlayerModel.MAX_HEALTH);
        this.UpdateHealthBar();
    }

    /// <summary>
    /// Chapter is selected load the next level
    /// </summary>
    /// <param name="chapterName"></param>
    public void UseChapter(string chapterName)
    {
        if (string.IsNullOrEmpty(chapterName))
            return;

        Application.LoadLevel(chapterName);
    }

    /// <summary>
    /// Implementation of interface method
    /// </summary>
    /// <param name="healingValue"></param>
    public void HealPlayer(int amount)
    {
        Debug.Log("2 PalyerController HealPlayer method " + amount.ToString());
        if (this.playerModel == null)
            return;

        this.playerModel.Health = (int)Mathf.Clamp(this.playerModel.Health + amount, 0.0f, PlayerModel.MAX_HEALTH);
        this.UpdateHealthBar();
    }

    /// <summary>
    /// 
    /// </summary>
    private void UpdateHealthBar()
    {
        if (this.heathBarSystem != null)
            this.heathBarSystem.SetHealth(((float)this.playerModel.Health) / ((float)PlayerModel.MAX_HEALTH));
    }
}
