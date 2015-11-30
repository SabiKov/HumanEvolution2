using UnityEngine;
using System.Collections;
/// <summary>
/// This class responsible for the view of the inventory frame panel.
/// The panel is calculated based on the custom values via UI 
/// </summary>
public class ResponsiveUI : MonoBehaviour {

    /// <summary>
    /// Properties
    /// </summary>

    // Enum, 
    public enum CalculationTypes
    {
        X,
        Y,
        BOTH
    } // end

    /// <summary>
    /// SizePercent: declare the size of the inventory panel, two parameters x  and y
    /// DependPanelTransform: depend on the canvas size
    /// CalculationTypes: which value is used to calculate the shape of the inventory panel
    /// </summary>
    public Vector2 SizePercent;
    public RectTransform DependPanelTransform;
    public CalculationTypes CalculationSizeType = CalculationTypes.BOTH;

    /// <summary>
    /// Initial the size of the panel
    /// </summary>
    public void Start()
    {
        this.CalculateSize();
    }
    /// <summary>
    /// 
    /// </summary>
    public void Update()
    {
        if (this.DependPanelTransform == null) { return; }
            
        this.CalculateSize();
    }

    /// <summary>
    /// Create the size of the inventory panel based on the parameters,
    /// finally, it returns a new size 
    /// </summary>
    /// <returns></returns>
    public Vector2 GetCalculatedSize()
    {
        var currentRectTransform = this.gameObject.GetComponent<RectTransform>();
        if (currentRectTransform == null || DependPanelTransform == null)
            return Vector2.zero;

        var newSize = new Vector2(currentRectTransform.sizeDelta.x, currentRectTransform.sizeDelta.y);
        switch (this.CalculationSizeType)
        {
            case CalculationTypes.X:
                newSize.x = DependPanelTransform.sizeDelta.x * this.SizePercent.x;
                break;
            case CalculationTypes.Y:
                newSize.y = DependPanelTransform.sizeDelta.y * this.SizePercent.y;
                break;
            case CalculationTypes.BOTH:
                newSize.x = DependPanelTransform.sizeDelta.x * this.SizePercent.x;
                newSize.y = DependPanelTransform.sizeDelta.y * this.SizePercent.y;
                break;
        }
        return newSize;
    }
    /// <summary>
    /// Calculate the size of the inventory panel
    /// </summary>
    public void CalculateSize()
    {
        var currentRectTransform = this.gameObject.GetComponent<RectTransform>();
        if (currentRectTransform == null || DependPanelTransform == null)
            return;

        currentRectTransform.sizeDelta = GetCalculatedSize();
    }
}
