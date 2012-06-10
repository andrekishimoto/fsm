//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // GuiButton
    //
    // A regular button with activated/selected/unselected states
    //-----------------------------------------------------------------------------
    public class GuiButton : GameEntity
    {
        protected GuiButtonType mType;
        protected GuiScreen mParent;

        protected Vector2 mPosition;
        protected StateMachine mFSM;

        protected Texture2D mBgCurrent;
        protected Texture2D mLabelCurrent;

        protected Texture2D mBgActivated;
        protected Texture2D mBgSelected;
        protected Texture2D mBgUnselected;

        protected Texture2D mLabelActivated;
        protected Texture2D mLabelSelected;
        protected Texture2D mLabelUnselected;

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GuiButton(EntityID id, GuiButtonType type, GuiScreen parent)
            : base(id)
        {
            mType = type;
            mParent = parent;

            mPosition = Vector2.Zero;
            mFSM = new StateMachine(this, GuiButtonConstants.BUTTON_FSM_UPDATE_DELAY_MILLISECONDS, GuiButtonStateUnselected.Instance());

            mBgCurrent = null;
            mLabelCurrent = null;

            mBgActivated = null;
            mBgSelected = null;
            mBgUnselected = null;

            mLabelActivated = null;
            mLabelSelected = null;
            mLabelUnselected = null;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void Construct(Vector2 position,
            Texture2D bgActivated,
            Texture2D bgSelected,
            Texture2D bgUnselected,
            Texture2D labelActivated,
            Texture2D labelSelected,
            Texture2D labelUnselected)
        {
            mPosition = position;

            mBgActivated = bgActivated;
            mBgSelected = bgSelected;
            mBgUnselected = bgUnselected;

            mLabelActivated = labelActivated;
            mLabelSelected = labelSelected;
            mLabelUnselected = labelUnselected;

            mBgCurrent = mBgUnselected;
            mLabelCurrent = labelUnselected;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void Destroy()
        {
            mBgActivated = null;
            mBgSelected = null;
            mBgUnselected = null;

            mLabelActivated = null;
            mLabelSelected = null;
            mLabelUnselected = null;

            if (mFSM != null)
            {
                mFSM.Destroy();
                mFSM = null;
            }

            mParent = null;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GuiScreen GetParent()
        {
            return mParent;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GuiButtonType GetButtonType()
        {
            return mType;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void SetButtonType(GuiButtonType type)
        {
            mType = type;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public Vector2 GetPosition()
        {
            return mPosition;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void SetPosition(Vector2 pos)
        {
            mPosition = pos;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void SetCurrent(GuiButtonStates state)
        {
            switch (state)
            {
                case GuiButtonStates.BUTTON_STATE_ACTIVATED:
                    mBgCurrent = mBgActivated;
                    mLabelCurrent = mLabelActivated;
                    break;

                case GuiButtonStates.BUTTON_STATE_SELECTED:
                    mBgCurrent = mBgSelected;
                    mLabelCurrent = mLabelSelected;
                    break;

                case GuiButtonStates.BUTTON_STATE_UNSELECTED:
                    mBgCurrent = mBgUnselected;
                    mLabelCurrent = mLabelUnselected;
                    break;
            }
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void SetState(GuiButtonStates state)
        {
            switch (state)
            {
                case GuiButtonStates.BUTTON_STATE_ACTIVATED:
                    mFSM.SetState(GuiButtonStateActivated.Instance());
                    break;

                case GuiButtonStates.BUTTON_STATE_SELECTED:
                    mFSM.SetState(GuiButtonStateSelected.Instance());
                    break;

                case GuiButtonStates.BUTTON_STATE_UNSELECTED:
                    mFSM.SetState(GuiButtonStateUnselected.Instance());
                    break;
            }
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(TimeSpan currentGameTime)
        {
            mFSM.Update(currentGameTime);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void Draw(TimeSpan currentGameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(mBgCurrent, mPosition, Color.White);
            spriteBatch.Draw(mLabelCurrent, mPosition, Color.White);
        }
    }
}
