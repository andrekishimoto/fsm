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
    // GuiScreenCredits
    //
    // Credits screen with only Back option
    //-----------------------------------------------------------------------------
    public class GuiScreenCredits : GuiScreen
    {
        private Texture2D mGameTitle;
        private Vector2 mGameTitlePos;

        private Texture2D mGameCredits;
        private Vector2 mGameCreditsPos;

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GuiScreenCredits(EntityID id, GuiScreenType type, ScreenManager parent, ContentManager contentManager)
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

            mGameCreditsPos = new Vector2(GuiScreenConstants.GAME_CREDITS_X, GuiScreenConstants.GAME_CREDITS_Y);
            mGameCredits = mContentManager.Load<Texture2D>(GuiScreenConstants.GAME_CREDITS_PATH);
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
            mButtons = new GuiButton[GuiScreenCreditsConstants.ENTITY_NAMES.Length];

            for (uint i = 0; i < mButtons.Length; ++i)
            {
                mButtons[i] = new GuiButton(GuiScreenCreditsConstants.ENTITY_NAMES[i], GuiScreenCreditsConstants.BUTTON_TYPE[i], this);
                mButtons[i].Construct(
                    new Vector2(GuiScreenCreditsConstants.BUTTON_INITIAL_X + (i * GuiScreenCreditsConstants.BUTTON_OFFSET_X),
                        GuiScreenCreditsConstants.BUTTON_INITIAL_Y + (i * GuiScreenCreditsConstants.BUTTON_OFFSET_Y)),
                    mContentManager.Load<Texture2D>(GuiScreenConstants.BUTTON_BACKGROUND_PATH[0]),
                    mContentManager.Load<Texture2D>(GuiScreenConstants.BUTTON_BACKGROUND_PATH[1]),
                    mContentManager.Load<Texture2D>(GuiScreenConstants.BUTTON_BACKGROUND_PATH[2]),
                    mContentManager.Load<Texture2D>(GuiScreenCreditsConstants.BUTTONS[i, 0]),
                    mContentManager.Load<Texture2D>(GuiScreenCreditsConstants.BUTTONS[i, 1]),
                    mContentManager.Load<Texture2D>(GuiScreenCreditsConstants.BUTTONS[i, 2]));
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
            spriteBatch.Draw(mGameCredits, mGameCreditsPos, Color.White);
        }
    }
}
