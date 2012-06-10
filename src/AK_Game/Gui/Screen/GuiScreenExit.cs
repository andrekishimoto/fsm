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
    // GuiScreenExit
    //
    // Exit screen with Yes/No options
    //-----------------------------------------------------------------------------
    public class GuiScreenExit : GuiScreen
    {
        private Texture2D mGameTitle;
        private Vector2 mGameTitlePos;

        private Texture2D mExitConfirmation;
        private Vector2 mExitConfirmationPos;

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GuiScreenExit(EntityID id, GuiScreenType type, ScreenManager parent, ContentManager contentManager)
            : base(id, type, parent, contentManager)
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Construct(Color backgroundColor, Texture2D backgroundTex)
        {
            base.Construct(backgroundColor, backgroundTex);

            mGameTitlePos = new Vector2(GuiScreenConstants.GAME_TITLE_X, GuiScreenConstants.GAME_TITLE_Y);
            mGameTitle = mContentManager.Load<Texture2D>(GuiScreenConstants.GAME_TITLE_PATH);

            mExitConfirmationPos = new Vector2(GuiScreenConstants.GAME_EXIT_X, GuiScreenConstants.GAME_EXIT_Y);
            mExitConfirmation = mContentManager.Load<Texture2D>(GuiScreenConstants.GAME_EXIT_PATH);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Destroy()
        {
            base.Destroy();
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        protected override void CreateButtons()
        {
            mButtons = new GuiButton[GuiScreenExitConstants.ENTITY_NAMES.Length];

            for (uint i = 0; i < mButtons.Length; ++i)
            {
                mButtons[i] = new GuiButton(GuiScreenExitConstants.ENTITY_NAMES[i], GuiScreenExitConstants.BUTTON_TYPE[i], this);
                mButtons[i].Construct(
                    new Vector2(GuiScreenExitConstants.BUTTON_INITIAL_X + (i * GuiScreenExitConstants.BUTTON_OFFSET_X),
                        GuiScreenExitConstants.BUTTON_INITIAL_Y + (i * GuiScreenExitConstants.BUTTON_OFFSET_Y)),
                    mContentManager.Load<Texture2D>(GuiScreenConstants.BUTTON_BACKGROUND_PATH[0]),
                    mContentManager.Load<Texture2D>(GuiScreenConstants.BUTTON_BACKGROUND_PATH[1]),
                    mContentManager.Load<Texture2D>(GuiScreenConstants.BUTTON_BACKGROUND_PATH[2]),
                    mContentManager.Load<Texture2D>(GuiScreenExitConstants.BUTTONS[i, 0]),
                    mContentManager.Load<Texture2D>(GuiScreenExitConstants.BUTTONS[i, 1]),
                    mContentManager.Load<Texture2D>(GuiScreenExitConstants.BUTTONS[i, 2]));
            }

            mCurrentButton = 0;
            mButtons[mCurrentButton].SetState(GuiButtonStates.BUTTON_STATE_SELECTED);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(TimeSpan currentGameTime)
        {
            base.Update(currentGameTime);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Draw(TimeSpan currentGameTime, SpriteBatch spriteBatch)
        {
            base.Draw(currentGameTime, spriteBatch);

            spriteBatch.Draw(mGameTitle, mGameTitlePos, Color.White); 
            spriteBatch.Draw(mExitConfirmation, mExitConfirmationPos, Color.White);
        }
    }
}
