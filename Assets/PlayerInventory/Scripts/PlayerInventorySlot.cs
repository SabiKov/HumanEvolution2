using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class PlayerInventorySlot : MonoBehaviour, IPointerClickHandler {

    /// <summary>
    /// List<PlayerInventoryItem> is a data structure to push and pop items in it which
    /// allows to stack variable top of each others.
    /// </summary>

    private List<PlayerInventoryItem> playerInventoryItem;
    //   public Text stackInfo;

    public Sprite slotEmpty;
    public Sprite slotHighlight;

    /// Boolean for checking content of the current slot 
    public bool IsEmpty {
        get { return playerInventoryItem.Count == 0; }      
    }
    /// The method returns the first item from the list data structure.
    public PlayerInventoryItem ItemSlot {
        get { return playerInventoryItem[0]; }
   }

   public List<PlayerInventoryItem> Item {
        get { return playerInventoryItem; }
        set { playerInventoryItem = value; }
   }

    /// <summary>
    /// - Instantiate List data structure itemStock when the script executes
    /// </summary>
    void Start() {

        playerInventoryItem = new List<PlayerInventoryItem>();
    }

    /// <summary>
    /// 
    /// </summary>
    void Update() {
    }
    /// <summary>
    /// Method is to update icon of item in slot when item is moved into other empty slot
    /// </summary>
    /// <param name="normal">normal sprite of item</param>
    /// <param name="hover">highlighted sprite of the item</param>
    private void UpdateSlotSprite(Sprite normalSprite, Sprite hoverSprite) {

        ///Access image property of slot prefab
        GetComponent<Image>().sprite = normalSprite;
        // Initial the state of the Sprite element
        SpriteState st = new SpriteState();
        st.pressedSprite = normalSprite;
        st.highlightedSprite = hoverSprite;
        /// Access the button component of slot prefab then sign to the state of the sprite
        GetComponent<Button>().spriteState = st;
    }

    /// <summary>
    /// Method is to add item to the list data structure
    /// </summary>
    public void AddItem(PlayerInventoryItem item) {
        playerInventoryItem.Add(item);

        ///Change the sprite in the slot
        UpdateSlotSprite(item.spriteNeutral, item.spriteHighlighted);
    }

    /// <summary>
    /// Method allows to use item from the inventory bag
    /// </summary>
    private void UseSlotItem() {
        if (!IsEmpty) {
            Debug.Log("Not empty");

            playerInventoryItem[0].SelectItemType();
            playerInventoryItem.RemoveAt(0);
        }

        if (IsEmpty) {
            UpdateSlotSprite(slotEmpty, slotHighlight);
            ///Increase the number of empty slot in PlyerInventoryGUI class.
            PlayerInventoryGUI.EmptySlots++;
        }
    }

    /// <summary>
    /// Implement interface of the IPointmouse Listener, it allows to click on element
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData) {
        ///It will be triggered on right mouse click event 
        if (eventData.button == PointerEventData.InputButton.Left) {
            UseSlotItem();
            Debug.Log("Event handler");
        }
    }

    public void ClearSlot() {
        playerInventoryItem.Clear();
        UpdateSlotSprite(slotEmpty, slotHighlight);
    }
} // end class
