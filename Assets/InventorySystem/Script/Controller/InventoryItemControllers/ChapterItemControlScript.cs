public class ChapterItemController: AbstractInventoryItemController {

    /// <summary>
    /// Each chapter item holds the next scene name
    /// </summary>
    private const string CHAPTER_NAME_1 = "";
    private const string CHAPTER_NAME_2 = "scene_2_exterior";
    private const string CHAPTER_NAME_3 = "scene_2_interior_daVinci";


    private string nextSceneName;

    public ChapterTypes ChapterType;

    /// <summary>
    /// which chapter is selected
    /// </summary>
    protected override void OnInventoryItemClicked()
    {
        this.nextSceneName = string.Empty;

        switch(ChapterType) {
            case ChapterTypes.CHAPTER_1:
                this.nextSceneName = CHAPTER_NAME_1;
                break;
            case ChapterTypes.CHAPTER_2:
                this.nextSceneName = CHAPTER_NAME_2;
                break;
            case ChapterTypes.CHAPTER_3:
                this.nextSceneName = CHAPTER_NAME_3;
                break;
        }

        if (PopupController.Instance != null)
            PopupController.Instance.ShowPopup(base.ItemDescriptior.Description, OnOkButtonClicked);
    }

    private void OnOkButtonClicked()
    {
        if(!string.IsNullOrEmpty(this.nextSceneName) && PlayerController.Instance != null)
           PlayerController.Instance.UseChapter(this.nextSceneName);
    }

}
