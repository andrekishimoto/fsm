//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // GuiScreenGame
    //
    // Game screen
    // This should be a container of game levels controlled by player progression,
    // similar to ScreenManager
    //-----------------------------------------------------------------------------
    public class GuiScreenGame : GuiScreen
    {
        protected StateMachine mFSM;

        protected GameLevel mCurrentLevel;

        protected GameLevel mTutorialLevel;

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GuiScreenGame(EntityID id, GuiScreenType type, ScreenManager parent, ContentManager contentManager)
            : base(id, type, parent, contentManager)
        {
            mFSM = null;

            mCurrentLevel = null;
            mTutorialLevel = null;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Construct(Color backgroundColor, Texture2D backgroundTex)
        {
            base.Construct(backgroundColor, backgroundTex);

            mFSM = new StateMachine(this, 0.0f, null);
            //mUpdateWaitMilliseconds = 0.0f;
         
            // Set first state inside OnEnter() method
            //SetState(GameStates.LEVEL_STATE_TUTORIAL);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Destroy()
        {
            if (mTutorialLevel != null)
            {
                mTutorialLevel.Destroy();
                mTutorialLevel = null;
            }

            mCurrentLevel = null;

            if (mFSM != null)
            {
                mFSM.Destroy();
                mFSM = null;
            }

            base.Destroy();
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameLevel GetCurrentLevel()
        {
            return mCurrentLevel;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void SetCurrentLevel(GameStates level)
        {
            switch (level)
            {
                case GameStates.LEVEL_STATE_TUTORIAL:
                    if (mTutorialLevel == null)
                    {
                        mTutorialLevel = new GameLevelTutorial(EntityID.GAME_LEVEL_TUTORIAL, this, mContentManager);
                        mTutorialLevel.Construct();
                    }
                    mCurrentLevel = mTutorialLevel;
                    break;
            }

            mCurrentLevel.OnEnter();
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void SetState(GameStates state)
        {
            switch (state)
            {
                case GameStates.LEVEL_STATE_TUTORIAL:
                    mFSM.SetState(GameStateTutorial.Instance());
                    break;
            }
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(TimeSpan currentGameTime)
        {
            UpdateInput(currentGameTime);

            mFSM.Update(currentGameTime);

            if (mCurrentLevel != null)
                mCurrentLevel.Update(currentGameTime);

            base.Update(currentGameTime);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Draw(TimeSpan currentGameTime, SpriteBatch spriteBatch)
        {
            base.Draw(currentGameTime, spriteBatch);

            if (mCurrentLevel != null)
                mCurrentLevel.Draw(currentGameTime, spriteBatch);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        protected override void UpdateInput(TimeSpan currentGameTime)
        {
            if (Utils.MustSkipFrame(mUpdateWaitMilliseconds, currentGameTime, mPreviousGameTime))
                return;

            KeyboardState keyboardState = Keyboard.GetState();

            // TODO: Open confirmation popup instead of going back to main menu
            if (keyboardState.IsKeyDown(Keys.Escape))
                mParent.SetState(GuiScreenStates.SCREEN_STATE_MAIN_MENU);

            mPreviousGameTime = currentGameTime;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void OnEnter()
        {
            base.OnEnter();

            // TODO: Set correct level
            if (mFSM.GetState() == null)
                SetState(GameStates.LEVEL_STATE_TUTORIAL);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void OnExit()
        {
            // TODO: Destroy correct level
            if (mTutorialLevel != null)
            {
                mTutorialLevel.Destroy();
                mTutorialLevel = null;
            }

            mFSM.ClearCurrentState();
        }
    }
}
