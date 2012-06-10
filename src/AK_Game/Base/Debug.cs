//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // Debug
    //
    // Wrapper for Console.WriteLine (can switch it on/off)
    //
    // TODO: Write output to a text file.
    //-----------------------------------------------------------------------------
    public static class Debug
    {
        public enum Flags
        {
            DEBUG_OFF = 0,
            DEBUG_GAME_MAIN = 1,
            DEBUG_STATE_MACHINE = 2,
            DEBUG_SCREENS = 4,
            DEBUG_BUTTONS = 8,
            DEBUG_LEVELS = 16,
            DEBUG_NPC = 32,
            DEBUG_ENTITY = 64,
            DEBUG_ALL = DEBUG_GAME_MAIN | DEBUG_STATE_MACHINE | DEBUG_SCREENS | DEBUG_BUTTONS | DEBUG_LEVELS | DEBUG_NPC | DEBUG_ENTITY
        };

        private static Flags mDebugMode = Flags.DEBUG_OFF;

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public static void EnableAll()
        {
            mDebugMode = Flags.DEBUG_ALL;
            Log(Flags.DEBUG_OFF, "Enabling all debug modes.");
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public static void DisableAll()
        {
            Log(Flags.DEBUG_OFF, "Disabling all debug modes.");
            mDebugMode = Flags.DEBUG_OFF;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public static void Enable(Debug.Flags mode)
        {
            mDebugMode |= mode;
            Log(Flags.DEBUG_OFF, "Enabling debug mode: {0}.", mode);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public static void Disable(Debug.Flags mode)
        {
            Log(Flags.DEBUG_OFF, "Disabling debug mode: {0}.", mode);
            mDebugMode &= ~mode;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public static void ToggleAll()
        {
            if (IsAllEnabled())
                DisableAll();
            else
                EnableAll();
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public static void Toggle(Debug.Flags mode)
        {
            if (IsEnabled(mode))
                Disable(mode);
            else
                Enable(mode);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public static bool IsAllEnabled()
        {
            return mDebugMode == Flags.DEBUG_ALL;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public static bool IsEnabled(Debug.Flags mode)
        {
            return (mDebugMode & mode) == mode;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public static void Clear()
        {
            Console.Clear();
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public static void Log(Debug.Flags mode, String message)
        {
            if ((mDebugMode & mode) == mode)
                Console.WriteLine(message);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public static void Log(Debug.Flags mode, String message, params Object[] arg)
        {
            if ((mDebugMode & mode) == mode)
                Console.WriteLine(message, arg);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public static void Log(Debug.Flags mode, string message, Object arg0, Object arg1)
        {
            if ((mDebugMode & mode) == mode)
                Console.WriteLine(message, arg0, arg1);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public static void Log(Debug.Flags mode, string message, Object arg0, Object arg1, Object arg2)
        {
            if ((mDebugMode & mode) == mode)
                Console.WriteLine(message, arg0, arg1, arg2);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public static void Log(Debug.Flags mode, string message, Object arg0, Object arg1, Object arg2, Object arg3)
        {
            if ((mDebugMode & mode) == mode)
                Console.WriteLine(message, arg0, arg1, arg2, arg3);
        }
    }
}
