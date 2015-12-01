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


    public static PopupController Instance;

    public Text InfoText;
    public Button OkButton;
    public Button CancelButton;


    public void Awake()
    {
        if(Instance == null)
            Instance = this;

        if (OkButton != null)
            OkButton.onClick.AddListener(OnOkButtonClicked);
        if (CancelButton != null)
            CancelButton.onClick.AddListener(OnCancelButtonClicked);

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
        if(InfoText != null)
            InfoText.text = message;

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
