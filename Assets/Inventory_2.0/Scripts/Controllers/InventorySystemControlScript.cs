using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

/// <summary>
/// Inventory control system responsible for
/// animation of panel and 
/// storing item into the system
/// The two required component attributes 
/// let automatically add required component as a dependency.
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(GridLayoutGroup))]
public class InventorySystemControlScript : MonoBehaviour, IInventorySystemControl {
    
    private float animationTimer;

    /// <summary>
    /// Component of the UI
    /// </summary>
    private GridLayoutGroup layoutGroup;
    private CanvasGroup canvasGroup;

    private InventoryAnimationStates animationState;

    private static List<GameObject> inventoryItems = new List<GameObject>();

    /// <summary>
    /// Controlling the state of the inventory
    /// </summary>
    public bool IsOpen { get; private set; }
    
    /// <summary>
    /// Declare the panel's item size and padding 
    /// </summary>
    [Header("Panel Settings")]
    public Vector2 itemSize = new Vector2(5, 5);
    public Vector2 spacing = new Vector2(0.0f, 0.0f);

    /// <summary>
    /// PropertyAttribute for animation settings
    /// </summary>
    [Header("Animation Settings")]
    public float animationSpeed = 1.0f;

    /// <summary>
    /// Property attribute of the slot's item 
    /// </summary>
    [Header("Item Settings")]
    public GameObject inventorySlotItem;

    /// <summary>
    /// Implementation of interface method
    /// </summary>
    /// <param name="item"></param>
    public void AddInventoryItem(GameObject item)
    {
        throw new NotImplementedException();
    }

    // Initial all game components and methods
    void Start()
    {
        this.animationState = InventoryAnimationStates.NONE;
        this.layoutGroup = this.gameObject.GetComponent<GridLayoutGroup>();
        this.canvasGroup = this.gameObject.GetComponent<CanvasGroup>();

        var responsiveUI = this.gameObject.GetComponent<ResponsiveUI>();

        if (responsiveUI != null) {
            responsiveUI.CalculateSize();
        }

        this.InitInventoryPanel();
        this.PopulateSlots();
//        this.PopulateItems();
    } // end init

    /// <summary>
    /// Control panel animation
    /// </summary>
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && this.animationState == InventoryAnimationStates.NONE)
            SwitchPopup();

        var deltaT = Time.deltaTime;
        if (this.animationState == InventoryAnimationStates.OPENING)
            StepOpeningAnimation(deltaT);
        else if (this.animationState == InventoryAnimationStates.CLOSING)
            StepClosingAnimation(deltaT);
    }

    private void StepOpeningAnimation(float deltaT)
    {
        var newAlpha = Mathf.SmoothStep(this.canvasGroup.alpha, 1.1f, deltaT * animationSpeed);
        this.canvasGroup.alpha = newAlpha;

        if (newAlpha >= 1.0f)
        {
            this.SetInventoryState(true);
            this.animationState = InventoryAnimationStates.NONE;
        }
    }

    private void StepClosingAnimation(float deltaT)
    {
        var newAlpha = Mathf.SmoothStep(this.canvasGroup.alpha, -0.1f, deltaT * animationSpeed);
        this.canvasGroup.alpha = newAlpha;

        if (newAlpha <= 0.0f)
        {
            this.SetInventoryState(false);
            this.animationState = InventoryAnimationStates.NONE;
        }
    }

    /// <summary>
    /// Calculate the layout of the inventory 
    /// panel based on its parameters
    /// </summary>
    private void InitInventoryPanel() {

        var panelRect = this.transform as RectTransform;

        if (panelRect == null) {
            return;
        } 

        /// Calculate the size
        this.layoutGroup.cellSize = new Vector2((panelRect.rect.width / itemSize.x) - (spacing.x * itemSize.x),
                                                (panelRect.rect.height / itemSize.y) - (spacing.y * itemSize.y));
    }

    private void PopulateSlots() {

        if (this.inventorySlotItem == null)
            return;

        for (int i = 0; i < itemSize.x * itemSize.y; i++)
        {
            var instance = Instantiate(this.inventorySlotItem);
            instance.transform.SetParent(this.transform);
            instance.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            var slotTransform = instance.transform as RectTransform;
            slotTransform.sizeDelta = new Vector2(this.layoutGroup.cellSize.x, this.layoutGroup.cellSize.y);
        }

    }
/*
    private void PopulateItems()
    {
        if (inventoryItems == null)
            return;

        foreach (var item in inventoryItems)
        {
            this.InstantinateObject(item, inventoryItems.IndexOf(item));
        }
    }
    */
/*
    /// <summary>
    /// Instantiate inventory item object and set positions
    /// </summary>
    private GameObject InstantinateObject(GameObject item, int slotIndex)
    {
        var slotItemTransform = this.gameObject.transform.GetChild(slotIndex) as RectTransform;
        if (slotItemTransform == null || slotItemTransform.childCount > 0)
            return null;

        var invItem = Instantiate(item);
        var itemScript = invItem.GetComponent<AbstractGameItemControlScript>();
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

 //       itemScript.ItemIndex = slotIndex;

        return invItem;
    }
    */
    private void SetInventoryState(bool isOpen)
    {
        this.IsOpen = isOpen;
        this.canvasGroup.interactable = isOpen;
        this.canvasGroup.blocksRaycasts = isOpen;
    }

    public List<GameObject> GetInventoryItems()
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// Implementation of interface method
    /// Opening feature of the inventory UI
    /// </summary>
    public void OpenInventory()
    {
        this.animationState = InventoryAnimationStates.OPENING;
    }
    /// <summary>
    /// Implementation of interface method
    /// Closing feature of the inventory UI
    /// </summary>
    public void CloseInventory()
    {
        this.animationState = InventoryAnimationStates.CLOSING;
    }
    /*
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
    */
    /// <summary>
    /// Checks and switch the inventory state 
    /// </summary>
    private void SwitchPopup()
    {
        if (this.IsOpen)
            this.CloseInventory();
        else
            this.OpenInventory();
    }

    public void RemoveInventoryItem(int itemIndex)
    {
        throw new NotImplementedException();
    }
}
