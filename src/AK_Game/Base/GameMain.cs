//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // GameMain
    //
    // Main game class
    //-----------------------------------------------------------------------------
    public class GameExample : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private ScreenManager mScreenManager;

        private TimeSpan mPreviousGameTime;

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameExample()
        {
            graphics = new GraphicsDeviceManager(this);

            Window.Title = Constants.SCREEN_NAME;
            graphics.PreferredBackBufferWidth = Constants.SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = Constants.SCREEN_HEIGHT;

            Console.Title = Constants.CONSOLE_NAME;
            Console.ForegroundColor = ConsoleColor.Green;

            Content.RootDirectory = "Content";

            Debug.EnableAll();
            Debug.Log(Debug.Flags.DEBUG_GAME_MAIN, "##########################");
            Debug.Log(Debug.Flags.DEBUG_GAME_MAIN, "   Initializing game...   ");
            Debug.Log(Debug.Flags.DEBUG_GAME_MAIN, "##########################");
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        protected override void Initialize()
        {
            base.Initialize();
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            mScreenManager = new ScreenManager(Content);
            mScreenManager.Construct();

            mPreviousGameTime = TimeSpan.Zero;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        protected override void UnloadContent()
        {
            if (mScreenManager != null)
                mScreenManager.Destroy();

            Content.Unload();
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        protected override void Update(GameTime gameTime)
        {
            if (mScreenManager.ShouldExit())
                this.Exit();

            mScreenManager.Update(gameTime.TotalGameTime);

            base.Update(gameTime);

            // Do not process input in each frame (options would be selected/unselected too fast)
            if (Utils.MustSkipFrame(Constants.UPDATE_WAIT_MILLISECONDS, gameTime.TotalGameTime, mPreviousGameTime))
                return;

            UpdateInput(gameTime.TotalGameTime);
    
            mPreviousGameTime = gameTime.TotalGameTime;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(mScreenManager.GetCurrentScreen().GetBackgroundColor());

            spriteBatch.Begin();
            {
                mScreenManager.Draw(gameTime.TotalGameTime, spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        private void UpdateInput(TimeSpan currentGameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.C))
                Debug.Clear();

            else if (Keyboard.GetState().IsKeyDown(Keys.D))
                Debug.ToggleAll();

            else if (Keyboard.GetState().IsKeyDown(Keys.D1))
                Debug.Toggle(Debug.Flags.DEBUG_GAME_MAIN);

            else if (Keyboard.GetState().IsKeyDown(Keys.D2))
                Debug.Toggle(Debug.Flags.DEBUG_STATE_MACHINE);

            else if (Keyboard.GetState().IsKeyDown(Keys.D3))
                Debug.Toggle(Debug.Flags.DEBUG_SCREENS);

            else if (Keyboard.GetState().IsKeyDown(Keys.D4))
                Debug.Toggle(Debug.Flags.DEBUG_BUTTONS);

            else if (Keyboard.GetState().IsKeyDown(Keys.D5))
                Debug.Toggle(Debug.Flags.DEBUG_LEVELS);

            else if (Keyboard.GetState().IsKeyDown(Keys.D6))
                Debug.Toggle(Debug.Flags.DEBUG_NPC);

            else if (Keyboard.GetState().IsKeyDown(Keys.D7))
                Debug.Toggle(Debug.Flags.DEBUG_ENTITY);
        }
    }
}
