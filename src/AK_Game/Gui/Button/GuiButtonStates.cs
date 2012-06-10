//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // GuiButtonStates
    //
    // Enum for all button states
    //-----------------------------------------------------------------------------
    public enum GuiButtonStates
    {
        BUTTON_STATE_ACTIVATED = 0,
        BUTTON_STATE_SELECTED,
        BUTTON_STATE_UNSELECTED,
    }

    //-----------------------------------------------------------------------------
    // GuiButtonStateActivated
    //
    // GuiButton state: Activated
    //-----------------------------------------------------------------------------
    public class GuiButtonStateActivated : IState
    {
        // Singleton
        private static GuiButtonStateActivated mInstance = null;
        public static GuiButtonStateActivated Instance()
        {
            if (mInstance == null)
                mInstance = new GuiButtonStateActivated();
            return mInstance;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GuiButtonStateActivated()
            : base()
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Enter(ref Object owner)
        {
            GuiButton button = (GuiButton)owner;
            button.SetCurrent(GuiButtonStates.BUTTON_STATE_ACTIVATED);

            // Block screen input
            button.GetParent().Block();

            Debug.Log(Debug.Flags.DEBUG_BUTTONS, "\t[ {0} - {1} ] GuiButtonStateActivated.Enter()", button.GetID(), button.GetButtonType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(ref Object owner, TimeSpan currentGameTime)
        {
            GuiButton button = (GuiButton)owner;

            button.SetState(GuiButtonStates.BUTTON_STATE_SELECTED);

            // Hmm... I guess this could be better (TODO)
            ScreenManager screenManager = button.GetParent().GetParent();
            switch (button.GetID())
            {
                case EntityID.BUTTON_MAINMENU_START:
                    screenManager.SetState(GuiScreenStates.SCREEN_STATE_GAME);
                    break;

                case EntityID.BUTTON_MAINMENU_CREDITS:
                    screenManager.SetState(GuiScreenStates.SCREEN_STATE_CREDITS);
                    break;

                case EntityID.BUTTON_MAINMENU_EXIT:
                    screenManager.SetState(GuiScreenStates.SCREEN_STATE_EXIT);
                    break;

                case EntityID.BUTTON_CREDITS_BACKTOMAINMENU:
                    screenManager.SetState(GuiScreenStates.SCREEN_STATE_MAIN_MENU);
                    break;

                case EntityID.BUTTON_EXIT_YES:
                    screenManager.SetShouldExit(true);
                    break;

                case EntityID.BUTTON_EXIT_NO:
                    screenManager.SetState(GuiScreenStates.SCREEN_STATE_MAIN_MENU);
                    break;
            }

            // Unblock screen input
            button.GetParent().Unblock();

            Debug.Log(Debug.Flags.DEBUG_BUTTONS, "\t[ {0} - {1} ] GuiButtonStateActivated.Update()", button.GetID(), button.GetButtonType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Exit(ref Object owner)
        {
            GuiButton button = (GuiButton)owner;
            Debug.Log(Debug.Flags.DEBUG_BUTTONS, "\t[ {0} - {1} ] GuiButtonStateActivated.Exit()", button.GetID(), button.GetButtonType());
        }
    }

    //-----------------------------------------------------------------------------
    // GuiButtonStateSelected
    //
    // GuiButton state: Selected
    //-----------------------------------------------------------------------------
    public class GuiButtonStateSelected : IState
    {
        // Singleton
        private static GuiButtonStateSelected mInstance = null;
        public static GuiButtonStateSelected Instance()
        {
            if (mInstance == null)
                mInstance = new GuiButtonStateSelected();
            return mInstance;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GuiButtonStateSelected()
            : base()
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Enter(ref Object owner)
        {
            GuiButton button = (GuiButton)owner;
            button.SetCurrent(GuiButtonStates.BUTTON_STATE_SELECTED);

            Debug.Log(Debug.Flags.DEBUG_BUTTONS, "\t[ {0} - {1} ] GuiButtonStateSelected.Enter()", button.GetID(), button.GetButtonType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(ref Object owner, TimeSpan currentGameTime)
        {
            GuiButton button = (GuiButton)owner;
            Debug.Log(Debug.Flags.DEBUG_BUTTONS, "\t[ {0} - {1} ] GuiButtonStateSelected.Update()", button.GetID(), button.GetButtonType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Exit(ref Object owner)
        {
            GuiButton button = (GuiButton)owner;
            Debug.Log(Debug.Flags.DEBUG_BUTTONS, "\t[ {0} - {1} ] GuiButtonStateSelected.Exit()", button.GetID(), button.GetButtonType());
        }
    }

    //-----------------------------------------------------------------------------
    // GuiButtonStateUnselected
    //
    // GuiButton state: Unselected
    //-----------------------------------------------------------------------------
    public class GuiButtonStateUnselected : IState
    {
        // Singleton
        private static GuiButtonStateUnselected mInstance = null;
        public static GuiButtonStateUnselected Instance()
        {
            if (mInstance == null)
                mInstance = new GuiButtonStateUnselected();
            return mInstance;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GuiButtonStateUnselected()
            : base()
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Enter(ref Object owner)
        {
            GuiButton button = (GuiButton)owner;
            button.SetCurrent(GuiButtonStates.BUTTON_STATE_UNSELECTED);

            Debug.Log(Debug.Flags.DEBUG_BUTTONS, "\t[ {0} - {1} ] GuiButtonStateUnselected.Enter()", button.GetID(), button.GetButtonType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(ref Object owner, TimeSpan currentGameTime)
        {
            GuiButton button = (GuiButton)owner;
            Debug.Log(Debug.Flags.DEBUG_BUTTONS, "\t[ {0} - {1} ] GuiButtonStateUnselected.Update()", button.GetID(), button.GetButtonType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Exit(ref Object owner)
        {
            GuiButton button = (GuiButton)owner;
            Debug.Log(Debug.Flags.DEBUG_BUTTONS, "\t[ {0} - {1} ] GuiButtonStateUnselected.Exit()", button.GetID(), button.GetButtonType());
        }
    }
}
