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
    // GuiScreenMainMenu
    //
    // Main menu screen with Start/Credits/Exit options
    //-----------------------------------------------------------------------------
    public class GuiScreenMainMenu : GuiScreen
    {
        private Texture2D mGameTitle;
        private Vector2 mGameTitlePos;

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GuiScreenMainMenu(EntityID id, GuiScreenType type, ScreenManager parent, ContentManager contentManager)
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
            mButtons = new GuiButton[GuiScreenMainMenuConstants.ENTITY_NAMES.Length];

            for (uint i = 0; i < mButtons.Length; ++i)
            {
                mButtons[i] = new GuiButton(GuiScreenMainMenuConstants.ENTITY_NAMES[i], GuiScreenMainMenuConstants.BUTTON_TYPE[i], this);
                mButtons[i].Construct(
                    new Vector2(GuiScreenMainMenuConstants.BUTTON_INITIAL_X + (i * GuiScreenMainMenuConstants.BUTTON_OFFSET_X),
                        GuiScreenMainMenuConstants.BUTTON_INITIAL_Y + (i * GuiScreenMainMenuConstants.BUTTON_OFFSET_Y)),
                    mContentManager.Load<Texture2D>(GuiScreenConstants.BUTTON_BACKGROUND_PATH[0]),
                    mContentManager.Load<Texture2D>(GuiScreenConstants.BUTTON_BACKGROUND_PATH[1]),
                    mContentManager.Load<Texture2D>(GuiScreenConstants.BUTTON_BACKGROUND_PATH[2]),
                    mContentManager.Load<Texture2D>(GuiScreenMainMenuConstants.BUTTONS[i, 0]),
                    mContentManager.Load<Texture2D>(GuiScreenMainMenuConstants.BUTTONS[i, 1]),
                    mContentManager.Load<Texture2D>(GuiScreenMainMenuConstants.BUTTONS[i, 2]));
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
        }
    }
}
