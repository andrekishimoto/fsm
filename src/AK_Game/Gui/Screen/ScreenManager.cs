//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // ScreenManager
    //
    // Manages all screens of the game (which means it manages the game flow)
    //-----------------------------------------------------------------------------
    public class ScreenManager
    {
        protected ContentManager mContentManager;

        protected StateMachine mFSM;

        protected GuiScreen mCurrentScreen;

        protected GuiScreenMainMenu mMainMenu;
        protected GuiScreenCredits mCredits;
        protected GuiScreenExit mExit;
        protected GuiScreenGame mGame;

        protected bool mShouldExit;

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public ScreenManager(ContentManager contentManager)
        {
            mContentManager = contentManager;
            mCurrentScreen = null;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void Construct()
        {
            mMainMenu = new GuiScreenMainMenu(EntityID.SCREEN_MAINMENU, GuiScreenType.SCREEN_MAIN_MENU, this, mContentManager);
            mMainMenu.Construct(Color.Black, null);

            mCredits = new GuiScreenCredits(EntityID.SCREEN_CREDITS, GuiScreenType.SCREEN_CREDITS, this, mContentManager);
            mCredits.Construct(Color.Black, null);

            mExit = new GuiScreenExit(EntityID.SCREEN_EXIT, GuiScreenType.SCREEN_EXIT, this, mContentManager);
            mExit.Construct(Color.Black, null);

            mGame = new GuiScreenGame(EntityID.SCREEN_GAME, GuiScreenType.SCREEN_GAME, this, mContentManager);
            // TODO: This background should be on level, not game screen
            mGame.Construct(Color.Black, mContentManager.Load<Texture2D>(GameLevelTutorialConstants.LEVEL_TUTORIAL_BACKGROUND));

            // mCurrentScreen will be set after SetState() call below
            //mCurrentScreen = mMainMenu;

            mFSM = new StateMachine(this, GuiScreenConstants.SCREEN_FSM_UPDATE_DELAY_MILLISECONDS, null);
            SetState(GuiScreenStates.SCREEN_STATE_MAIN_MENU);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void Destroy()
        {
            if (mMainMenu != null)
            {
                mMainMenu.Destroy();
                mMainMenu = null;
            }

            if (mCredits != null)
            {
                mCredits.Destroy();
                mCredits = null;
            }

            if (mExit != null)
            {
                mExit.Destroy();
                mExit = null;
            }

            if (mGame != null)
            {
                mGame.Destroy();
                mGame = null;
            }

            mCurrentScreen = null;

            if (mFSM != null)
            {
                mFSM.Destroy();
                mFSM = null;
            }
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void SetShouldExit(bool shouldExit)
        {
            mShouldExit = shouldExit;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public bool ShouldExit()
        {
            return mShouldExit;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GuiScreen GetCurrentScreen()
        {
            return mCurrentScreen;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void SetCurrent(GuiScreenStates state)
        {
            switch (state)
            {
                case GuiScreenStates.SCREEN_STATE_MAIN_MENU:
                    mCurrentScreen = mMainMenu;
                    break;

                case GuiScreenStates.SCREEN_STATE_CREDITS:
                    mCurrentScreen = mCredits;
                    break;

                case GuiScreenStates.SCREEN_STATE_EXIT:
                    mCurrentScreen = mExit;
                    break;

                case GuiScreenStates.SCREEN_STATE_GAME:
                    mCurrentScreen = mGame;
                    break;
            }
            
            mCurrentScreen.OnEnter();
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void SetState(GuiScreenStates state)
        {
            switch (state)
            {
                case GuiScreenStates.SCREEN_STATE_MAIN_MENU:
                    mFSM.SetState(GuiScreenStateMainMenu.Instance());
                    break;

                case GuiScreenStates.SCREEN_STATE_CREDITS:
                    mFSM.SetState(GuiScreenStateCredits.Instance());
                    break;

                case GuiScreenStates.SCREEN_STATE_EXIT:
                    mFSM.SetState(GuiScreenStateExit.Instance());
                    break;

                case GuiScreenStates.SCREEN_STATE_GAME:
                    mFSM.SetState(GuiScreenStateGame.Instance());
                    break;
            }
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void Update(TimeSpan currentGameTime)
        {
            mFSM.Update(currentGameTime);

            if (mCurrentScreen != null)
                mCurrentScreen.Update(currentGameTime);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void Draw(TimeSpan currentGameTime, SpriteBatch spriteBatch)
        {
            if (mCurrentScreen != null)
                mCurrentScreen.Draw(currentGameTime, spriteBatch);
        }
    }
}
