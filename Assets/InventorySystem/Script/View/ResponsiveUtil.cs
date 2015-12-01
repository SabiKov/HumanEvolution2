using UnityEngine;

public class ResponsiveUtil : MonoBehaviour {

    #region Properties

    #region Enums
    public enum CalculationTypes
    {
        X,
        Y,
        BOTH
    }

    #endregion

    public Vector2 SizePercent;
    public RectTransform DependPanelTransform;
    public CalculationTypes CalculationSizeType = CalculationTypes.BOTH;

    #endregion

    public void Start()
    {
        this.CalculateSize();
    }

    public void Update() {
        if (this.DependPanelTransform == null)
            return;

        this.CalculateSize();
    }

    #region Utils

    public Vector2 GetCalculatedSize()
    {
        var currentRectTransform = this.gameObject.GetComponent<RectTransform>();
        if (currentRectTransform == null || DependPanelTransform == null)
            return Vector2.zero;

        var newSize = new Vector2(currentRectTransform.sizeDelta.x, currentRectTransform.sizeDelta.y);
        switch (this.CalculationSizeType) {
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

    public void CalculateSize()
    {
        var currentRectTransform = this.gameObject.GetComponent<RectTransform>();
        if (currentRectTransform == null || DependPanelTransform == null)
            return;

        currentRectTransform.sizeDelta = GetCalculatedSize();
    }

    #endregion

}
