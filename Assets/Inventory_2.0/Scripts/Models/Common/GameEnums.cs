using UnityEngine;
using System.Collections;

/// <summary>
/// Declare all the Enumeration Data Type of the game
/// </summary>

    public enum ChapterTypes
    {
        CHAPTER_1,
        CHAPTER_2,
        CHAPTER_3
    }

    public enum InventoryAnimationStates
    {
        OPENING,
        CLOSING,
        NONE
    }

    public enum GameItemTypes
    {
        INVENTORY_ITEM,
        DEADLY_DAMAGE,
        SMALL_DAMAGE
    }

    public enum GameItemAnimationTypes
    {
        ANIM_ROTATE,
        ANIM_LIFT,
        BOTH,
        NONE
    }
