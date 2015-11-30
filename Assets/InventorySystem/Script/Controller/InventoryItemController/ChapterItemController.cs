using UnityEngine;
using System.Collections;

public class ChapterItemController : AbstractInventoryItemController
{
        /// <summary>
        /// Declare scenes name
        /// </summary>
        private const string CHAPTER_NAME_1 = "";
        private const string CHAPTER_NAME_2 = "scene_2";
        private const string CHAPTER_NAME_3 = "scene_3";

        private string nextSceneName;

        public ChapterTypes ChapterType;

        protected override void OnInventoryItemClicked()
        {
            this.nextSceneName = string.Empty;

            switch (ChapterType)
            {
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
            if (!string.IsNullOrEmpty(this.nextSceneName) && PlayerController.Instance != null)
                PlayerController.Instance.UseChapter(this.nextSceneName);
        }
}
