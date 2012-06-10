//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // GameLevelTutorialConstants
    //
    // Constants for GameLevelTutorial
    //-----------------------------------------------------------------------------
    public static class GameLevelTutorialConstants
    {
        public const String LEVEL_TUTORIAL_BACKGROUND = "Assets\\House";
        public const String LEVEL_TUTORIAL_ROOM_SELECTED = "Assets\\RoomSelected";
        public const String LEVEL_TUTORIAL_ROOM_UNSELECTED = "Assets\\RoomUnselected";
        
        public const int LEVEL_TUTORIAL_NPC_QTY = 1;

        public const float BAR_INITIAL_X = 10.0f;
        public const float BAR_INITIAL_Y = 10.0f;

        public const float BAR_OFFSET_X = 0.0f;
        public const float BAR_OFFSET_Y = 20.0f;

        public const float BAR_SCALE_FACTOR_X = 10.0f;
        public const float BAR_SCALE_FACTOR_Y = 10.0f;

        public const float ROOM_SELECTION_Y = 93.0f;
    }
}
