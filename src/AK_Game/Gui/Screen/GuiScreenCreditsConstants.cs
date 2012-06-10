//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // GuiScreenCreditsConstants
    //
    // Constants for GuiScreenCredits
    //-----------------------------------------------------------------------------
    public static class GuiScreenCreditsConstants
    {
        public static String[,] BUTTONS = {
                                                { // "Back"
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonBack_Activated",
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonBack_Selected",
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonBack_Unselected"
                                                }
                                          };

        public static EntityID[] ENTITY_NAMES = {
                                                    EntityID.BUTTON_CREDITS_BACKTOMAINMENU
                                                };

        public static GuiButtonType[] BUTTON_TYPE = {
                                                        GuiButtonType.BUTTON_BACK_TO_MAIN_MENU
                                                    };

        public const int BUTTON_QTY = 1;

        public const float BUTTON_INITIAL_X = 210.0f;
        public const float BUTTON_INITIAL_Y = 333.0f;

        public const float BUTTON_OFFSET_X = 0.0f;
        public const float BUTTON_OFFSET_Y = 57.0f;
    }
}
