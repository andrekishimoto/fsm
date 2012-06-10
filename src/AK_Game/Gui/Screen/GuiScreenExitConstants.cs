//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // GuiScreenExitConstants
    //
    // Constants for GuiScreenExit
    //-----------------------------------------------------------------------------
    public static class GuiScreenExitConstants
    {
        public static String[,] BUTTONS = {
                                                { // "Yes"
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonYes_Activated",
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonYes_Selected",
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonYes_Unselected"
                                                },
                                                { // "No"
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonNo_Activated",
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonNo_Selected",
                                                    GuiScreenConstants.PARENT_BUTTON_PATH + "ButtonNo_Unselected"
                                                }
                                          };

        public static EntityID[] ENTITY_NAMES = {
                                                    EntityID.BUTTON_EXIT_YES,
                                                    EntityID.BUTTON_EXIT_NO
                                                };

        public static GuiButtonType[] BUTTON_TYPE = {
                                                        GuiButtonType.BUTTON_YES,
                                                        GuiButtonType.BUTTON_NO
                                                    };

        public const int BUTTON_QTY = 2;

        public const float BUTTON_INITIAL_X = 210.0f;
        public const float BUTTON_INITIAL_Y = 333.0f;

        public const float BUTTON_OFFSET_X = 0.0f;
        public const float BUTTON_OFFSET_Y = 57.0f;
    }
}
