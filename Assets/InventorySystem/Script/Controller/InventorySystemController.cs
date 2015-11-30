using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// Inventory control system:
///  - control panel animation
///  - store inventory items
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(GridLayoutGroup))]
public class InventorySystemController : MonoBehaviour, IInventorySystemController {

    /// <summary>
    /// animationTimer: holds value of fade in and out feature 
    /// layoutGroup: property of the inv.panel
    /// canvasGroup: property of the inv.panel
    /// </summary>
    private float animationTimer;
    private GridLayoutGroup layoutGroup;
    private CanvasGroup canvasGroup;

    /// <summary>
    /// Holds items object
    /// </summary>
    private static List<GameObject> inventoryItems = new List<GameObject>();
    /// <summary>
    /// Set and access the current state of the inv.panel
    /// </summary>
    public bool IsOpen { get; private set; }

    /// <summary>
    /// ItemSize: - x value represents the row value, inv.slot
    ///           - y value represents the column value of inv.slot 
    /// Spacing: padding value of item, but x and y values are used for calculation
    /// </summary>
    [Header("Panel Settings")]
    public Vector2 SlotSize = new Vector2(5, 5);
    public Vector2 Spacing = new Vector2(0.0f, 0.0f);
    /// <summary>
    /// Declare the fade in/out animation speed
    /// </summary>
    [Header("Animation Settings")]
    public float AnimationSpeed = 1.0f;

    /// <summary>
    /// Declare Slot prefab 
    /// </summary>
    [Header("Item Settings")]
    public GameObject InventorySlotItem;

    private InventoryAnimationStates animationState;



    // Use this for initialization
    private void Start () {
        this.animationState = InventoryAnimationStates.NONE;
        this.layoutGroup = this.gameObject.GetComponent<GridLayoutGroup>();
        this.canvasGroup = this.gameObject.GetComponent<CanvasGroup>();

        var responsiveUI = this.gameObject.GetComponent<ResponsiveUI>();
        if (responsiveUI != null)
            responsiveUI.CalculateSize();

        this.InitInventoryPanel();
        this.PopulateSlots();
        this.PopulateItems();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I) && this.animationState == InventoryAnimationStates.NONE)
            SwitchOpenCloseInventory();

        var deltaT = Time.deltaTime;
        if (this.animationState == InventoryAnimationStates.OPENING)
            StepOpeningAnimation(deltaT);
        else if (this.animationState == InventoryAnimationStates.CLOSING)
            StepClosingAnimation(deltaT);
    }

    /// <summary>
    /// Calculate layout cell size based on panel size
    /// </summary>
    private void InitInventoryPanel()
    {
        var panelRect = this.transform as RectTransform;
        if (panelRect == null)
            return;

        this.layoutGroup.cellSize = new Vector2((panelRect.rect.width / SlotSize.x) - (Spacing.x * SlotSize.x),
                                                (panelRect.rect.height / SlotSize.y) - (Spacing.y * SlotSize.y));
    }
    /// <summary>
    /// Instantiate slot items 
    /// </summary>
    private void PopulateSlots()
    {
        if (this.InventorySlotItem == null)
            return;

        for (int i = 0; i < SlotSize.x * SlotSize.y; i++)
        {
            var instance = Instantiate(this.InventorySlotItem);
            instance.transform.SetParent(this.transform);
            instance.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            var slotTransform = instance.transform as RectTransform;
            slotTransform.sizeDelta = new Vector2(this.layoutGroup.cellSize.x, this.layoutGroup.cellSize.y);
        }
    } // end populate slot
    
    /// <summary>
    /// Adding items into inventory panel
    /// </summary>
    private void PopulateItems()
    {
        if (inventoryItems == null)
            return;

        foreach (var item in inventoryItems)
        {
            this.InstantinateObject(item, inventoryItems.IndexOf(item));
        }
    }
      

    /// <summary>
    /// Opening inventory panel with fading feature
    /// </summary>
    /// <param name="deltaT">time value</param>
    private void StepOpeningAnimation(float deltaT)
    {
        var newAlpha = Mathf.SmoothStep(this.canvasGroup.alpha, 1.1f, deltaT * AnimationSpeed);
        this.canvasGroup.alpha = newAlpha;

        if (newAlpha >= 1.0f)
        {
            this.SetInventoryState(true);
            this.animationState = InventoryAnimationStates.NONE;
        }
    }
    /// <summary>
    /// Closing inventory panel with fading feature
    /// </summary>
    /// <param name="deltaT">time value</param>
    private void StepClosingAnimation(float deltaT)
    {
        var newAlpha = Mathf.SmoothStep(this.canvasGroup.alpha, -0.1f, deltaT * AnimationSpeed);
        this.canvasGroup.alpha = newAlpha;

        if (newAlpha <= 0.0f)
        {
            this.SetInventoryState(false);
            this.animationState = InventoryAnimationStates.NONE;
        }
    }

    public List<GameObject> GetInventoryItems()
    {
        return inventoryItems;
    }
    /// <summary>
    /// Add item to inventory
    /// </summary>
    /// <param name="item">GameObject with AbstractInventoryItemControlScript component</param>
    public void AddInventoryItem(GameObject item)
    {
        if (item == null)
            return;

        var instance = InstantinateObject(item, inventoryItems.Count);
        if (instance != null)
        {
            inventoryItems.Add(item);
        }
    }

    /// <summary>
    /// Remove item from inventory
    /// </summary>
    /// <param name="itemIndex">Item index</param>
    public void RemoveInventoryItem(int itemIndex)
    {
        if (itemIndex < 0 || itemIndex > inventoryItems.Count - 1)
            return;

        var slotItem = this.transform.GetChild(itemIndex);
        if (slotItem == null)
            return;

        var inventoryItem = slotItem.GetChild(0);
        if (inventoryItem == null)
            return;

        inventoryItems.RemoveAt(itemIndex);
        Destroy(inventoryItem.gameObject);
    }

    /// <summary>
    /// Instantiate inventory item object and set positions
    /// </summary>
    private GameObject InstantinateObject(GameObject item, int slotIndex)
    {
        var slotItemTransform = this.gameObject.transform.GetChild(slotIndex) as RectTransform;
        if (slotItemTransform == null || slotItemTransform.childCount > 0)
            return null;

        var invItem = Instantiate(item);
        var itemScript = invItem.GetComponent<AbstractInventoryItemController>();
        if (itemScript == null)
        {
            Destroy(invItem);
            Debug.LogWarning("Wrong item added to inventory!");
            return null;
        }

        var invItemTransform = invItem.transform as RectTransform;
        invItemTransform.SetParent(slotItemTransform);
        invItemTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        invItemTransform.sizeDelta = slotItemTransform.sizeDelta;
        invItemTransform.localPosition = Vector3.zero;

        itemScript.ItemIndex = slotIndex;

        return invItem;
    }


    /// <summary>
    /// When the boolean value is true the inventory panel is set to visible on the scene
    /// </summary>
    /// <param name="isOpen">the inventory panel open</param>
    private void SetInventoryState(bool isOpen)
    {
        this.IsOpen = isOpen;
        this.canvasGroup.interactable = isOpen;
        this.canvasGroup.blocksRaycasts = isOpen;
    }
    /// <summary>
    /// Switch between the open close state of the inventory panel
    /// </summary>
    private void SwitchOpenCloseInventory()
    {
        if (this.IsOpen) { this.CloseInventory(); }
        else
            this.CloseInventory();
    }
    /// <summary>
    /// Implementation of Interface's method
    /// </summary>
    public void CloseInventory()
    {
        this.animationState = InventoryAnimationStates.CLOSING;
    }

    public void OpenInventory()
    {
        this.animationState = InventoryAnimationStates.OPENING;
    }


}
