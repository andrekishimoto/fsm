//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // GameStates
    //
    // Enum for all game levels
    //-----------------------------------------------------------------------------
    public enum GameStates
    {
        LEVEL_STATE_TUTORIAL = 0,
    }

    //-----------------------------------------------------------------------------
    // GameStateTutorial
    //
    // Game level: Tutorial
    //-----------------------------------------------------------------------------
    public class GameStateTutorial : IState
    {
        // Singleton
        private static GameStateTutorial mInstance = null;
        public static GameStateTutorial Instance()
        {
            if (mInstance == null)
                mInstance = new GameStateTutorial();
            return mInstance;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameStateTutorial()
            : base()
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Enter(ref Object owner)
        {
            GuiScreenGame gameScreen = (GuiScreenGame)owner;
            gameScreen.SetCurrentLevel(GameStates.LEVEL_STATE_TUTORIAL);

            //Debug.Log("[ {0} ] GameStateTutorial.Enter()", gameScreen.GetCurrentLevel().GetID());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(ref Object owner, TimeSpan currentGameTime)
        {
            GuiScreenGame gameScreen = (GuiScreenGame)owner;
            GameLevel gameLevel = gameScreen.GetCurrentLevel();

            //if (gameLevel == null)
                //Debug.Log("[ERROR] GameStateTutorial.Update() - no game level loaded");
            //else
            //    //Debug.Log("[ {0} ] GameStateTutorial.Update()", gameLevel.GetID());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Exit(ref Object owner)
        {
            GuiScreenGame gameScreen = (GuiScreenGame)owner;
            //Debug.Log("[ {0} ] GameStateTutorial.Exit()", gameScreen.GetCurrentLevel().GetID());
        }
    }
}
