//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // GameNPCConstants
    //
    // Constants for NPC's
    //-----------------------------------------------------------------------------
    public static class GameNPCConstants
    {
        public const float NPC_UPDATE_DELAY_MILLISECONDS = 100.0f;
        public const float NPC_TECH_SLAVE_UPDATE_DELAY_MILLISECONDS = 1000.0f;

        public const float NPC_EAT_UPDATE_AMOUNT = 0.3f;
        public const float NPC_EAT_INSIDE_UPDATE_AMOUNT = -NPC_EAT_UPDATE_AMOUNT;
        public const float NPC_EAT_TRIGGER_AMOUNT = 6.0f;

        public const float NPC_SLEEP_UPDATE_AMOUNT = 0.1f;
        public const float NPC_SLEEP_INSIDE_UPDATE_AMOUNT = -NPC_SLEEP_UPDATE_AMOUNT * 4.0f;
        public const float NPC_SLEEP_TRIGGER_AMOUNT = 8.0f;

        public const float NPC_RELIEVE_UPDATE_AMOUNT = 0.1f;
        public const float NPC_RELIEVE_INSIDE_UPDATE_AMOUNT = -NPC_RELIEVE_UPDATE_AMOUNT * 2.0f;
        public const float NPC_RELIEVE_TRIGGER_AMOUNT = 6.6f;

        public const float NPC_LIFE_UPDATE_AMOUNT = -0.01f;
        public const float NPC_LIFE_INSIDE_UPDATE_AMOUNT = NPC_LIFE_UPDATE_AMOUNT;
        public const float NPC_LIFE_TRIGGER_AMOUNT = 0.0f;
        
        public const float NPC_TECH_SLAVE_INITIAL_LIFE = 10.0f;
    }
}
