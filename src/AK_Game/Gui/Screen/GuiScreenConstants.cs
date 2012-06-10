//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // GuiScreenConstants
    //
    // Constants for GuiScreen
    //-----------------------------------------------------------------------------
    public static class GuiScreenConstants
    {
        public const String GAME_TITLE_PATH = "Assets\\UI\\GameTitle";
        public const float GAME_TITLE_X = 132.0f;
        public const float GAME_TITLE_Y = 64.0f;

        public const String GAME_CREDITS_PATH = "Assets\\UI\\GameCredits";
        public const float GAME_CREDITS_X = 85.0f;
        public const float GAME_CREDITS_Y = 221.0f;

        public const String GAME_EXIT_PATH = "Assets\\UI\\GameExit";
        public const float GAME_EXIT_X = 202.0f;
        public const float GAME_EXIT_Y = 221.0f;//71.0f;

        public const String PARENT_BUTTON_PATH = "Assets\\Button\\";
        public static String[] BUTTON_BACKGROUND_PATH = { // Button background (used by all buttons)
                                                            PARENT_BUTTON_PATH + "ButtonBg_Activated",
                                                            PARENT_BUTTON_PATH + "ButtonBg_Selected",
                                                            PARENT_BUTTON_PATH + "ButtonBg_Unselected"
                                                        };

        public const float DEFAULT_INPUT_UPDATE_DELAY_MILLISECONDS = 100.0f;

        public const float SCREEN_FSM_UPDATE_DELAY_MILLISECONDS = 1000.0f;
    }

    //-----------------------------------------------------------------------------
    // GuiScreenType
    //
    // Enum for all screens in the game
    //-----------------------------------------------------------------------------
    public enum GuiScreenType
    {
        SCREEN_MAIN_MENU = 0,
        SCREEN_CREDITS,
        SCREEN_EXIT,
        SCREEN_GAME
    }
}
