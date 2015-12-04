
/// <summary>
/// Holds number of available pages/chapters
/// </summary>
public enum ChapterTypes
{
    CHAPTER_1,
    CHAPTER_2,
    CHAPTER_3,  // skipped, lack of scene_3
    CHAPTER_4
}

/// <summary>
/// Holds the state of the inventory
/// </summary>
public enum InventoryAnimationStates
{
    OPENING,
    CLOSING,
    NONE
}

/// <summary>
/// Holds type of inventory item
/// </summary>
public enum GameItemTypes
{
    INVENTORY_ITEM,
    DEADLY_DAMAGE,
    LEARN_STATION
}

/// <summary>
/// Holds Type of animation control
/// </summary>
public enum GameItemAnimationTypes
{
    ANIM_ROTATE,
    ANIM_LIFT,
    BOTH,
    NONE
}