using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Abstract class for game items.
/// </summary>
[RequireComponent(typeof(Collider))]
public abstract class AbstractInventorytemControlScript : MonoBehaviour
{

    private Button itemButton;

    /// <summary>
    /// Item slot index
    /// </summary>
    public int ItemIndex { get; set; }
    
    /// <summary>
    /// Store informations about inventory item
    /// </summary>
  /*  [Header("Descriptor Settings")]
    public InventoryItemDescriptor ItemDescriptior;
    */
    private void Awake()
    {
        this.itemButton = this.gameObject.GetComponent<Button>();
        this.itemButton.onClick.AddListener(OnInventoryItemClicked);
    }

    protected void DoDestory()
    {
        if (PlayerControlScript.Instance != null)
            PlayerControlScript.Instance.RemoveInventoryItem(this.gameObject);

        Destroy(this.gameObject);
    }

    /// <summary>
    /// Do inventory item effect.
    /// Called when player clicked on it.
    /// </summary>
    protected virtual void OnInventoryItemClicked()
    {
        Debug.Log("Inventory item clicked");
        DoDestory();
    }
}