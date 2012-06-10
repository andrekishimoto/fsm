//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // GameConstants
    //
    // Constants for Game
    //-----------------------------------------------------------------------------
    public static class GameConstants
    {
        public const String PLACEHOLDER_NPC = "Assets\\Placeholder_Npc";
    }

    //-----------------------------------------------------------------------------
    // GameLevelType
    //
    // Enum for all levels in the game
    //-----------------------------------------------------------------------------
    public enum GameLevelType
    {
        LEVEL_DEFAULT = 0,
        LEVEL_TUTORIAL,
    }

    //-----------------------------------------------------------------------------
    // GameObjectType
    //
    // Enum for all objects in the game
    //-----------------------------------------------------------------------------
    public enum GameObjectType
    {
        GAME_OBJECT_DEFAULT = 0,
        GAME_OBJECT_BAR,
        GAME_OBJECT_NPC,
        GAME_OBJECT_NPC_TECH_SLAVE,
    }
}
