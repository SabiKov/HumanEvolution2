using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// This class is responsible for displaying all UI element of the inventory system.
/// The first section contains public and private variables.
/// The second section contains gets and sets method which allow to send and receive data from inherited classes.
/// The third section contains the update and start functions. 
/// The last section contains all methods and functions. These functions are used by different functions and classes.   
///  
/// </summary>
public class PlayerInventoryGUI : MonoBehaviour {

    /// <summary>
    /// Create variables for declaring inventory bag's size
    /// </summary>
    private RectTransform inventoryGUIRect;
    private float invWidth, invHeight;
    private static int emptySlots;

    /// <summary>
    /// Adding open/close functionalities to inventory bag
    /// </summary>
    public CanvasGroup canvas;
    public EventSystem eventSystem;
    private bool open;

    /// <summary>
    /// Create public variables which can be set via UI 
    /// columns: number of columns
    /// rows: number of rows
    /// leftSpace: add "left" distance between slots
    /// rightSpace: add "right" distance between slots
    /// prefab: add slot prefab
    /// </summary>
    public GameObject prefabSlot;
    public int columns;
    public int rows;
    public float slotSizeWidth;
    public float slotSizeHeight;
    private int slots;
    private float leftSpace = 5;
    private float topSpace = 5;

    /// <summary>
    /// Create a array list to store all inventory bag's slots as a game object
    /// </summary>
    private List<GameObject> allSlots = new List<GameObject>();

    /// <summary>
    /// Method allows to access the emptySlot private variable from other class 
    /// </summary>
    public static int EmptySlots {
        get {
            return emptySlots;
        }

        set {
            emptySlots = value;
        }
    }

    // Use this for initialization
    void Start() {

        BuildInventoryBag();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            OpenCloseInventory();
        }
        //     DisplayLivesLeft();
    }

    /// <summary>
    /// Create a layout of the inventory bag, based on the custom parameters
    /// </summary>
    private void BuildInventoryBag() {
        // Calculate the total slots of the inventory bag
        slots = rows * columns;
        emptySlots = slots;

        /// <summary>
        /// Calculate the size of the inventory bag based on number of slots + their width and height
        /// </summary>
        invWidth = (columns) * (slotSizeWidth + leftSpace) + leftSpace;
        invHeight = (rows) * (slotSizeHeight + topSpace) + topSpace;
        //Access the inventory bag recTarnsform element
        inventoryGUIRect = GetComponent<RectTransform>();
        // resize the width and height of inventory 2D UI image object
        inventoryGUIRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, invWidth);
        inventoryGUIRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, invHeight);

        /// Nested forLoop going to add slots into inventory bag.
        /// X and Y positions are calculated based on the slot's width, height, "spaces" parameters
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // Create extra slots within the inventory bag by instantiating the slot prefab 
                GameObject generateSlot = (GameObject)Instantiate(prefabSlot);

                //Create a rectangular shape for the slot
                RectTransform slotRect = generateSlot.GetComponent<RectTransform>();

                // rename the extraSlot
                generateSlot.name = "Slot";
                /// set the canvas element as a parent of the dynamically build slots
                generateSlot.transform.SetParent(this.transform.parent);

                /// Calculate the x and y position of slot by adding width and height of slot
                float xAxis = leftSpace * (j + 1) + (slotSizeWidth * j) + (slotSizeWidth / 2);
                float yAxis = (-topSpace * (i + 1) - (slotSizeHeight / 2)) - ((slotSizeHeight * i));

                /// set the position of slot inside the inventory bag
                slotRect.localPosition = inventoryGUIRect.localPosition + new Vector3(xAxis, yAxis);

                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSizeWidth);
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSizeHeight);

                // added newly generate slot to the array list data structure
                allSlots.Add(generateSlot);
            }
        }
    } // BuildInventoryBag
    /// <summary>
    /// Open and Close Function of the inventory
    /// </summary>
    /// <returns></returns>
    private void OpenCloseInventory() {
        if (canvas.alpha > 0) {
            Debug.Log("Canvas Close");
            canvas.alpha = 0;
        }
        else
        {
            Debug.Log("Canvas display");
            canvas.alpha = 1;
        }
    }
    /// <summary>
    /// Adding item to empty slot, the method return true if item can be added into an empty slot
    /// otherwise return false which means the slot is occupied by another item. 
    /// </summary>
    /// <param name="item">passing an item form PlayerInventory class</param>
    /// <returns></returns>
    public bool AddItem(PlayerInventoryItem item) {
        if (item.stockSize == 1) {
            AddItemInEmptySlot(item);
            return true;
        }
        return false;
    }
    /// <summary>
    /// Add item to empty slot
    /// </summary>
    /// <param name="itemStock"></param>
    /// <returns></returns>
    private bool AddItemInEmptySlot(PlayerInventoryItem itemStock) {
        ///Check available empty slot in the bag
        if (emptySlots > 0) {
            /// Looping through the inventory bag to count number of empty slots.
            foreach (GameObject slot in allSlots) {
                PlayerInventorySlot tmpSlot = slot.GetComponent<PlayerInventorySlot>();
                ///if the temporary slot is empty,item will added and remove 
                if (tmpSlot.IsEmpty) {
                    tmpSlot.AddItem(itemStock);
                    emptySlots--;
                    return true;
                }
            }
        }
        return false;
    } 
    /*
        /// <summary>
        /// Saving all item from inventory system
        /// </summary>
        public void SaveInventoryItem() {

            for (int i = 0; i < allSlots.Count; i++) {

                /// Store each slot item into a variable, called "tmpSlot"  

                PlayerInventorySlot tmpSlot = allSlots[i].GetComponent<PlayerInventorySlot>();

                if (!tmpSlot.IsEmpty) {

                    ContentSizeFitter == i + "," + tmpSlot.Se; 

                }
            }
        }
        */
}
