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
    // GuiScreen
    //
    // Base screen with background color, background texture and array (container)
    // of buttons
    // Buttons are selected using up/down arrows (but a screen can also have no
    // buttons)
    //-----------------------------------------------------------------------------
    public class GuiScreen : GameEntity
    {
        protected GuiScreenType mType;
        protected ScreenManager mParent;

        protected ContentManager mContentManager;

        protected Color mBackgroundColor;
        protected Texture2D mBackgroundTex;

        protected GuiButton[] mButtons;
        protected int mCurrentButton;

        protected float mUpdateWaitMilliseconds;
        protected TimeSpan mPreviousGameTime;

        protected bool mIsBlocked;

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GuiScreen(EntityID id, GuiScreenType type, ScreenManager parent, ContentManager contentManager)
            : base(id)
        {
            mType = type;
            mParent = parent;

            mContentManager = contentManager;

            mBackgroundColor = Color.Black;
            mBackgroundTex = null;

            mButtons = null;

            mUpdateWaitMilliseconds = 0.0f;
            mPreviousGameTime = TimeSpan.Zero;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void Construct(Color backgroundColor, Texture2D backgroundTex)
        {
            CreateButtons();

            mUpdateWaitMilliseconds = GuiScreenConstants.DEFAULT_INPUT_UPDATE_DELAY_MILLISECONDS;

            mBackgroundColor = backgroundColor;
            mBackgroundTex = backgroundTex;

            mIsBlocked = false;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void Destroy()
        {
            DestroyButtons();

            mBackgroundTex = null;

            mContentManager = null;

            mParent = null;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        protected virtual void CreateButtons()
        {
            mCurrentButton = 0;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        protected virtual void DestroyButtons()
        {
            if (mButtons != null)
            {
                for (int i = 0; i < mButtons.Length; ++i)
                {
                    mButtons[i].Destroy();
                    mButtons[i] = null;
                }
                mButtons = null;
            }
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public ScreenManager GetParent()
        {
            return mParent;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GuiScreenType GetScreenType()
        {
            return mType;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void SetScreenType(GuiScreenType type)
        {
            mType = type;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public Color GetBackgroundColor()
        {
            return mBackgroundColor;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void SetBackgroundColor(Color color)
        {
            mBackgroundColor = color;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public bool IsBlocked()
        {
            return mIsBlocked;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void Block()
        {
            mIsBlocked = true;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void Unblock()
        {
            mIsBlocked = false;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void SetUpdateWaitMilliseconds(float milliseconds)
        {
            mUpdateWaitMilliseconds = milliseconds;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(TimeSpan currentGameTime)
        {
            if (mIsBlocked)
                mPreviousGameTime = currentGameTime;
            else
                UpdateInput(currentGameTime);

            if (mButtons != null)
            {
                for (int i = 0; i < mButtons.Length; ++i)
                    mButtons[i].Update(currentGameTime);
            }
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void Draw(TimeSpan currentGameTime, SpriteBatch spriteBatch)
        {
            if (mBackgroundTex != null)
                spriteBatch.Draw(mBackgroundTex, Vector2.Zero, Color.White);

            if (mButtons != null)
            {
                for (int i = 0; i < mButtons.Length; ++i)
                    mButtons[i].Draw(currentGameTime, spriteBatch);
            }
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        protected virtual void UpdateInput(TimeSpan currentGameTime)
        {
            if (Utils.MustSkipFrame(mUpdateWaitMilliseconds, currentGameTime, mPreviousGameTime))
                return;

            if (mButtons != null)
            {
                KeyboardState keyboardState = Keyboard.GetState();

                if (keyboardState.IsKeyDown(Keys.Enter) || keyboardState.IsKeyDown(Keys.Space))
                {
                    mButtons[mCurrentButton].SetState(GuiButtonStates.BUTTON_STATE_ACTIVATED);
                }

                else if (keyboardState.IsKeyDown(Keys.Up) && mCurrentButton > 0)
                {
                    mButtons[mCurrentButton].SetState(GuiButtonStates.BUTTON_STATE_UNSELECTED);
                    mCurrentButton--;
                    mButtons[mCurrentButton].SetState(GuiButtonStates.BUTTON_STATE_SELECTED);
                }

                else if (keyboardState.IsKeyDown(Keys.Down) && mCurrentButton < mButtons.Length - 1)
                {
                    mButtons[mCurrentButton].SetState(GuiButtonStates.BUTTON_STATE_UNSELECTED);
                    mCurrentButton++;
                    mButtons[mCurrentButton].SetState(GuiButtonStates.BUTTON_STATE_SELECTED);
                }
            }

            mPreviousGameTime = currentGameTime;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void OnEnter()
        {
            if (mButtons != null)
            {
                for (uint i = 0; i < mButtons.Length; ++i)
                {
                    mButtons[i].SetState(GuiButtonStates.BUTTON_STATE_UNSELECTED);
                }

                mCurrentButton = 0;
                mButtons[mCurrentButton].SetState(GuiButtonStates.BUTTON_STATE_SELECTED);
            }
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void OnExit()
        {
        }
    }
}
