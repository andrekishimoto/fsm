//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // GuiButtonConstants
    //
    // Constants for GuiButton
    //-----------------------------------------------------------------------------
    public static class GuiButtonConstants
    {
        public const float BUTTON_FSM_UPDATE_DELAY_MILLISECONDS = 1000.0f;
    }

    //-----------------------------------------------------------------------------
    // GuiButtonType
    //
    // Enum for all buttons in the game
    //-----------------------------------------------------------------------------
    public enum GuiButtonType
    {
        BUTTON_START = 0,
        BUTTON_CREDITS,
        BUTTON_EXIT,
        BUTTON_BACK_TO_MAIN_MENU,
        BUTTON_YES,
        BUTTON_NO
    }
}
