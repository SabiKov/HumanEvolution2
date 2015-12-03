public class ChapterItemController: AbstractInventoryItemController {

    /// <summary>
    /// Each chapter item holds the next scene name
    /// </summary>
    private const string CHAPTER_NAME_1 = "scene_2_exterior";
    private const string CHAPTER_NAME_2 = "scene_4";
    private const string CHAPTER_NAME_3 = "";
    private const string CHAPTER_NAME_4 = "GameWon";

    private string nextSceneName;

    public ChapterTypes chapterType;

    /// <summary>
    /// which chapter is selected the nextSceneName is signed 
    /// to the corresponding item
    /// </summary>
    protected override void OnInventoryItemClicked()
    {
        this.nextSceneName = string.Empty;

        switch(chapterType) {
            case ChapterTypes.CHAPTER_1:
                this.nextSceneName = CHAPTER_NAME_1;
                break;
            case ChapterTypes.CHAPTER_2:
                this.nextSceneName = CHAPTER_NAME_2;
                break;
            case ChapterTypes.CHAPTER_3:
                this.nextSceneName = CHAPTER_NAME_3;
                break;
            case ChapterTypes.CHAPTER_4:
                this.nextSceneName = CHAPTER_NAME_4;
                break;
        }
        // show on popup selected chapter with descriptor string
        if (PopupController.instance != null)
            PopupController.instance.ShowPopup(base.ItemDescriptior.Description, OnOkButtonClicked);
    }

    private void OnOkButtonClicked()
    {
        if(!string.IsNullOrEmpty(this.nextSceneName) && PlayerController.instance != null)
           PlayerController.instance.UseChapter(this.nextSceneName);

        DestroyChapterFromInventory();
    }

    /// <summary>
    /// Destroy chapter object after fired
    /// </summary>
    private void DestroyChapterFromInventory()
    {
        if (PlayerController.instance == null)
            return;

        base.DoDestory();
    }

}
