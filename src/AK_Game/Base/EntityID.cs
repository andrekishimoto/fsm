//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // EntityID
    //
    // Enum for all entities in the game (including GUI)
    //-----------------------------------------------------------------------------
    public enum EntityID
    {
        // Main menu screen
        SCREEN_MAINMENU = 0,
        BUTTON_MAINMENU_START,
        BUTTON_MAINMENU_CREDITS,
        BUTTON_MAINMENU_EXIT,

        // Credits screen
        SCREEN_CREDITS,
        BUTTON_CREDITS_BACKTOMAINMENU,

        // Exit screen
        SCREEN_EXIT,
        BUTTON_EXIT_YES,
        BUTTON_EXIT_NO,

        // Game screen
        SCREEN_GAME,

        // Game level: Tutorial
        GAME_LEVEL_TUTORIAL,
        TUTORIAL_ROOM_SELECTED,
        TUTORIAL_ROOM_UNSELECTED_0,
        TUTORIAL_ROOM_UNSELECTED_1,
        TUTORIAL_ROOM_UNSELECTED_2,
        TUTORIAL_NPC,
        TUTORIAL_LIFE_BAR,
        TUTORIAL_EAT_BAR,
        TUTORIAL_SLEEP_BAR,
        TUTORIAL_RELIEVE_BAR,
    }
}
