using System;
using UnityEngine;


public class ResponsiveUI : MonoBehaviour {

    /// <summary>
    /// Properties of the switch statement
    /// </summary>
    public enum CalculationTypes {

        X,Y,BOTH
    }

    /// <summary>
    /// 
    /// </summary>
    public Vector2 sizePercent;
    public RectTransform dependPanelTransform;
    public CalculationTypes calculationSizeType = CalculationTypes.BOTH;

    /// <summary>
    /// Initial UI component on start
    /// </summary>
    public void Start() {

        this.CalculateSize();
    }
    /// <summary>
    /// Method calculates by every frame 
    /// </summary>
    public void Update() {

        if (this.dependPanelTransform == null) { return; }

        this.CalculateSize();
    }

    public Vector2 GetCalculatedSize() {

        var currentRectTransform = this.gameObject.GetComponent<RectTransform>();

        if (currentRectTransform == null || dependPanelTransform == null) {
            return Vector2.zero;
        }

        var newSize = new Vector2(currentRectTransform.sizeDelta.x, currentRectTransform.sizeDelta.y);

        switch(calculationSizeType) {
            case CalculationTypes.X:
                newSize.x = dependPanelTransform.sizeDelta.x * this.sizePercent.x;
                break;
            case CalculationTypes.Y:
                newSize.y = dependPanelTransform.sizeDelta.y * this.sizePercent.y;
                break;
            case CalculationTypes.BOTH:
                newSize.x = dependPanelTransform.sizeDelta.x * this.sizePercent.x;
                newSize.y = dependPanelTransform.sizeDelta.y * this.sizePercent.y;
                break;
        }
        
        return newSize;
    }
    /// <summary>
    /// Calculates the size of the inventory panel
    /// </summary>
    public void CalculateSize()
    {
        var currentRectTransform = this.gameObject.GetComponent<RectTransform>();

        if (currentRectTransform == null || dependPanelTransform == null)
        {
            return;
        }

        currentRectTransform.sizeDelta = GetCalculatedSize();
    }
    
}
