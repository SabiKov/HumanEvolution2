using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Abstract class for inventory item script
/// </summary>
[RequireComponent(typeof(Button))]
public abstract class AbstractInventoryItemController : MonoBehaviour
{

    /// <summary>
    /// Declare button for item
    /// </summary>
    private Button itemButton;

    /// <summary>
    /// Setter and Getter of item slot index
    /// </summary>
    public int ItemIndex { get; set; }

    /// <summary>
    /// Store informations about inventory item
    /// </summary>
    [Header("Descriptor Settings")]
    public InventoryItemDescriptor ItemDescriptior;

    /// <summary>
    /// initialize (Slot)buttons component and its listeners before the game starts.
    /// </summary>
    private void Awake()
    {
        this.itemButton = this.gameObject.GetComponent<Button>();
        this.itemButton.onClick.AddListener(OnInventoryItemClicked);
    }
    /// <summary>
    /// Destroy item when is selected by player, if the sot is not empty
    /// </summary>
    protected void DoDestory()
    {
        if(PlayerController.instance != null)
            PlayerController.instance.RemoveInventoryItem(this.gameObject);

        Destroy(this.gameObject);
    }

    /// <summary>
    /// Do inventory item effect.
    /// Called when the (Slot)button is selected.
    /// </summary>
    protected virtual void OnInventoryItemClicked()
    {
        Debug.Log("Inventory item clicked");
        DoDestory();
    }

}
