//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // GuiScreenMainMenuConstants
    //
    // Constants for GuiScreenMainMenu
    //-----------------------------------------------------------------------------
    public static class GuiScreenMainMenuConstants
    {
        public static String[,] BUTTONS = {
                                                { // "Start"
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonStart_Activated",
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonStart_Selected",
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonStart_Unselected"
                                                },
                                                { // "Credits"
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonCredits_Activated",
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonCredits_Selected",
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonCredits_Unselected"
                                                },
                                                { // "Exit"
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonExit_Activated",
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonExit_Selected",
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonExit_Unselected"
                                                }
                                          };

        public static EntityID[] ENTITY_NAMES = {
                                                    EntityID.BUTTON_MAINMENU_START,
                                                    EntityID.BUTTON_MAINMENU_CREDITS,
                                                    EntityID.BUTTON_MAINMENU_EXIT
                                                };

        public static GuiButtonType[] BUTTON_TYPE = {
                                                        GuiButtonType.BUTTON_START,
                                                        GuiButtonType.BUTTON_CREDITS,
                                                        GuiButtonType.BUTTON_EXIT
                                                    };

        public const int BUTTON_QTY = 3;

        public const float BUTTON_INITIAL_X = 210.0f;
        public const float BUTTON_INITIAL_Y = 276.0f;

        public const float BUTTON_OFFSET_X = 0.0f;
        public const float BUTTON_OFFSET_Y = 57.0f;
    }
}
