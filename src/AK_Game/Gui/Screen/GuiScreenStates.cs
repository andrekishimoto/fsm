//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // GuiScreenStates
    //
    // Enum for all ScreenManager states
    //-----------------------------------------------------------------------------
    public enum GuiScreenStates
    {
        SCREEN_STATE_MAIN_MENU = 0,
        SCREEN_STATE_CREDITS,
        SCREEN_STATE_EXIT,
        SCREEN_STATE_GAME
    }

    //-----------------------------------------------------------------------------
    // GuiScreenStateMainMenu
    //
    // ScreenManager state: Main menu
    //-----------------------------------------------------------------------------
    public class GuiScreenStateMainMenu : IState
    {
        // Singleton
        private static GuiScreenStateMainMenu mInstance = null;
        public static GuiScreenStateMainMenu Instance()
        {
            if (mInstance == null)
                mInstance = new GuiScreenStateMainMenu();
            return mInstance;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GuiScreenStateMainMenu()
            : base()
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Enter(ref Object owner)
        {
            ScreenManager screen = (ScreenManager)owner;
            screen.SetCurrent(GuiScreenStates.SCREEN_STATE_MAIN_MENU);

            Debug.Log(Debug.Flags.DEBUG_SCREENS, "[ {0} - {1} ] GuiScreenStateMainMenu.Enter()", screen.GetCurrentScreen().GetID(), screen.GetCurrentScreen().GetScreenType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(ref Object owner, TimeSpan currentGameTime)
        {
            ScreenManager screen = (ScreenManager)owner;
            Debug.Log(Debug.Flags.DEBUG_SCREENS, "[ {0} - {1} ] GuiScreenStateMainMenu.Update()", screen.GetCurrentScreen().GetID(), screen.GetCurrentScreen().GetScreenType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Exit(ref Object owner)
        {
            ScreenManager screen = (ScreenManager)owner;
            screen.GetCurrentScreen().OnExit();

            Debug.Log(Debug.Flags.DEBUG_SCREENS, "[ {0} - {1} ] GuiScreenStateMainMenu.Exit()", screen.GetCurrentScreen().GetID(), screen.GetCurrentScreen().GetScreenType());
        }
    }

    //-----------------------------------------------------------------------------
    // GuiScreenStateCredits
    //
    // ScreenManager state: Credits
    //-----------------------------------------------------------------------------
    public class GuiScreenStateCredits : IState
    {
        // Singleton
        private static GuiScreenStateCredits mInstance = null;
        public static GuiScreenStateCredits Instance()
        {
            if (mInstance == null)
                mInstance = new GuiScreenStateCredits();
            return mInstance;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GuiScreenStateCredits()
            : base()
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Enter(ref Object owner)
        {
            ScreenManager screen = (ScreenManager)owner;
            screen.SetCurrent(GuiScreenStates.SCREEN_STATE_CREDITS);

            Debug.Log(Debug.Flags.DEBUG_SCREENS, "[ {0} - {1} ] GuiScreenStateCredits.Enter()", screen.GetCurrentScreen().GetID(), screen.GetCurrentScreen().GetScreenType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(ref Object owner, TimeSpan currentGameTime)
        {
            ScreenManager screen = (ScreenManager)owner;
            Debug.Log(Debug.Flags.DEBUG_SCREENS, "[ {0} - {1} ] GuiScreenStateCredits.Update()", screen.GetCurrentScreen().GetID(), screen.GetCurrentScreen().GetScreenType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Exit(ref Object owner)
        {
            ScreenManager screen = (ScreenManager)owner;
            screen.GetCurrentScreen().OnExit();

            Debug.Log(Debug.Flags.DEBUG_SCREENS, "[ {0} - {1} ] GuiScreenStateCredits.Exit()", screen.GetCurrentScreen().GetID(), screen.GetCurrentScreen().GetScreenType());
        }
    }

    //-----------------------------------------------------------------------------
    // GuiScreenStateExit
    //
    // ScreenManager state: Exit
    //-----------------------------------------------------------------------------
    public class GuiScreenStateExit : IState
    {
        // Singleton
        private static GuiScreenStateExit mInstance = null;
        public static GuiScreenStateExit Instance()
        {
            if (mInstance == null)
                mInstance = new GuiScreenStateExit();
            return mInstance;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GuiScreenStateExit()
            : base()
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Enter(ref Object owner)
        {
            ScreenManager screen = (ScreenManager)owner;
            screen.SetCurrent(GuiScreenStates.SCREEN_STATE_EXIT);

            Debug.Log(Debug.Flags.DEBUG_SCREENS, "[ {0} - {1} ] GuiScreenStateExit.Enter()", screen.GetCurrentScreen().GetID(), screen.GetCurrentScreen().GetScreenType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(ref Object owner, TimeSpan currentGameTime)
        {
            ScreenManager screen = (ScreenManager)owner;
            Debug.Log(Debug.Flags.DEBUG_SCREENS, "[ {0} - {1} ] GuiScreenStateExit.Update()", screen.GetCurrentScreen().GetID(), screen.GetCurrentScreen().GetScreenType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Exit(ref Object owner)
        {
            ScreenManager screen = (ScreenManager)owner;
            screen.GetCurrentScreen().OnExit();

            Debug.Log(Debug.Flags.DEBUG_SCREENS, "[ {0} - {1} ] GuiScreenStateExit.Exit()", screen.GetCurrentScreen().GetID(), screen.GetCurrentScreen().GetScreenType());
        }
    }

    //-----------------------------------------------------------------------------
    // GuiScreenStateGame
    //
    // ScreenManager state: Game
    //-----------------------------------------------------------------------------
    public class GuiScreenStateGame : IState
    {
        // Singleton
        private static GuiScreenStateGame mInstance = null;
        public static GuiScreenStateGame Instance()
        {
            if (mInstance == null)
                mInstance = new GuiScreenStateGame();
            return mInstance;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GuiScreenStateGame()
            : base()
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Enter(ref Object owner)
        {
            ScreenManager screen = (ScreenManager)owner;
            screen.SetCurrent(GuiScreenStates.SCREEN_STATE_GAME);

            Debug.Log(Debug.Flags.DEBUG_SCREENS, "[ {0} - {1} ] GuiScreenStateGame.Enter()", screen.GetCurrentScreen().GetID(), screen.GetCurrentScreen().GetScreenType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(ref Object owner, TimeSpan currentGameTime)
        {
            ScreenManager screen = (ScreenManager)owner;
            Debug.Log(Debug.Flags.DEBUG_SCREENS, "[ {0} - {1} ] GuiScreenStateGame.Update()", screen.GetCurrentScreen().GetID(), screen.GetCurrentScreen().GetScreenType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Exit(ref Object owner)
        {
            ScreenManager screen = (ScreenManager)owner;
            screen.GetCurrentScreen().OnExit();

            Debug.Log(Debug.Flags.DEBUG_SCREENS, "[ {0} - {1} ] GuiScreenStateGame.Exit()", screen.GetCurrentScreen().GetID(), screen.GetCurrentScreen().GetScreenType());
        }
    }

}
