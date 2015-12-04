using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public class PopupController : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    private UnityAction yesCallback;
    private UnityAction noCallback;

    private CanvasGroup canvasGroup;


    public static PopupController instance;

    public Text infoText;
    public Button okButton;
    public Button cancelButton;


    public void Awake()
    {
        if(instance == null)
            instance = this;

        if (okButton != null)
            okButton.onClick.AddListener(OnOkButtonClicked);
        if (cancelButton != null)
            cancelButton.onClick.AddListener(OnCancelButtonClicked);

        this.canvasGroup = this.gameObject.GetComponent<CanvasGroup>();

        this.HidePopup();
    }

    /// <summary>
    /// EvenHandler is triggered by mouse click 
    /// </summary>
    public void OnOkButtonClicked()
    {
        if (this.yesCallback != null)
            this.yesCallback();

        this.HidePopup();
    }

    public void OnCancelButtonClicked()
    {
        if (this.noCallback != null)
            this.noCallback();

        this.HidePopup();
    }

    public void ShowPopup(string message, UnityAction yesCallback = null, UnityAction noCallback = null)
    {
        if(infoText != null)
            infoText.text = message;

        this.yesCallback = yesCallback;
        this.noCallback = noCallback;

        this.canvasGroup.alpha = 1.0f;
        this.gameObject.SetActive(true);
    }

    public void HidePopup()
    {
        this.canvasGroup.alpha = 0.0f;
        this.gameObject.SetActive(false);
    }

}
