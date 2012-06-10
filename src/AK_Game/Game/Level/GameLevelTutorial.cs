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
    // GameLevelTutorial
    //
    // A game level to exemplify the FSM implementation
    //-----------------------------------------------------------------------------
    public class GameLevelTutorial : GameLevel
    {
        protected GameNPC_TechSlave mNPC;

        protected GameObject mRoomSelected;
        protected GameObject[] mRoomUnselected;

        protected GameBar mLifeBar;
        protected GameBar mEatBar;
        protected GameBar mSleepBar;
        protected GameBar mRelieveBar;

        // TODO: Add GamePlayer and level-related Objects once they are created.

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameLevelTutorial(EntityID id, GuiScreen parent, ContentManager contentManager)
            : base(id, parent, contentManager)
        {
            mType = GameLevelType.LEVEL_TUTORIAL;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameLevelTutorial(EntityID id, GameLevelType type, GuiScreen parent, ContentManager contentManager)
            : base(id, type, parent, contentManager)
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        protected override void InitializeMembers(GuiScreen parent, ContentManager contentManager)
        {
            base.InitializeMembers(parent, contentManager);

            mNPC = null;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Construct()
        {
            base.Construct();

            mRoomSelected = new GameObject(EntityID.TUTORIAL_ROOM_SELECTED);
            mRoomSelected.Construct(mContentManager.Load<Texture2D>(GameLevelTutorialConstants.LEVEL_TUTORIAL_ROOM_SELECTED), new Vector2(0.0f, GameLevelTutorialConstants.ROOM_SELECTION_Y));

            EntityID[] unselectedID = {
                                          EntityID.TUTORIAL_ROOM_UNSELECTED_0,
                                          EntityID.TUTORIAL_ROOM_UNSELECTED_1,
                                          EntityID.TUTORIAL_ROOM_UNSELECTED_2
                                      };
            mRoomUnselected = new GameObject[3];
            for (int i = 0; i < mRoomUnselected.Length; ++i)
            {
                mRoomUnselected[i] = new GameObject(unselectedID[i]);
                mRoomUnselected[i].Construct(mContentManager.Load<Texture2D>(GameLevelTutorialConstants.LEVEL_TUTORIAL_ROOM_UNSELECTED), new Vector2(0.0f, GameLevelTutorialConstants.ROOM_SELECTION_Y));
            }

            // Only one NPC
            mNPC = new GameNPC_TechSlave(EntityID.TUTORIAL_NPC, this);
            mNPC.Construct(mContentManager.Load<Texture2D>(GameConstants.PLACEHOLDER_NPC), Vector2.Zero);

            mLifeBar = new GameBar(EntityID.TUTORIAL_LIFE_BAR);
            mLifeBar.Construct(mContentManager.Load<Texture2D>("Assets\\UI\\LifeBar"),
                new Vector2(GameLevelTutorialConstants.BAR_INITIAL_X, GameLevelTutorialConstants.BAR_INITIAL_Y));
            mLifeBar.SetScaleFactorY(GameLevelTutorialConstants.BAR_SCALE_FACTOR_Y);

            mEatBar = new GameBar(EntityID.TUTORIAL_EAT_BAR);
            mEatBar.Construct(mContentManager.Load<Texture2D>("Assets\\UI\\EatBar"),
                new Vector2(GameLevelTutorialConstants.BAR_INITIAL_X + GameLevelTutorialConstants.BAR_OFFSET_X,
                    GameLevelTutorialConstants.BAR_INITIAL_Y + GameLevelTutorialConstants.BAR_OFFSET_Y));
            mEatBar.SetScaleFactorY(GameLevelTutorialConstants.BAR_SCALE_FACTOR_Y);

            mSleepBar = new GameBar(EntityID.TUTORIAL_SLEEP_BAR);
            mSleepBar.Construct(mContentManager.Load<Texture2D>("Assets\\UI\\SleepBar"),
                new Vector2(GameLevelTutorialConstants.BAR_INITIAL_X + GameLevelTutorialConstants.BAR_OFFSET_X * 2,
                    GameLevelTutorialConstants.BAR_INITIAL_Y + GameLevelTutorialConstants.BAR_OFFSET_Y * 2));
            mSleepBar.SetScaleFactorY(GameLevelTutorialConstants.BAR_SCALE_FACTOR_Y);

            mRelieveBar = new GameBar(EntityID.TUTORIAL_RELIEVE_BAR);
            mRelieveBar.Construct(mContentManager.Load<Texture2D>("Assets\\UI\\RelieveBar"),
                new Vector2(GameLevelTutorialConstants.BAR_INITIAL_X + GameLevelTutorialConstants.BAR_OFFSET_X * 3,
                    GameLevelTutorialConstants.BAR_INITIAL_Y + GameLevelTutorialConstants.BAR_OFFSET_Y * 3));
            mRelieveBar.SetScaleFactorY(GameLevelTutorialConstants.BAR_SCALE_FACTOR_Y);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Destroy()
        {
            base.Destroy();

            if (mNPC != null)
            {
                mNPC.Destroy();
                mNPC = null;
            }
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(TimeSpan currentGameTime)
        {
            base.Update(currentGameTime);

            for (int i = 0; i < mRoomUnselected.Length; ++i)
                mRoomUnselected[i].Update(currentGameTime);

            mRoomSelected.Update(currentGameTime);

            if (mNPC != null)
            {
                mNPC.Update(currentGameTime);

                mLifeBar.SetScaleFactorX(mNPC.GetLifeCounter() * GameLevelTutorialConstants.BAR_SCALE_FACTOR_X);
                mEatBar.SetScaleFactorX(mNPC.GetEatCounter() * GameLevelTutorialConstants.BAR_SCALE_FACTOR_X);
                mSleepBar.SetScaleFactorX(mNPC.GetSleepCounter() * GameLevelTutorialConstants.BAR_SCALE_FACTOR_X);
                mRelieveBar.SetScaleFactorX(mNPC.GetRelieveCounter() * GameLevelTutorialConstants.BAR_SCALE_FACTOR_X);
            }
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Draw(TimeSpan currentGameTime, SpriteBatch spriteBatch)
        {
            base.Draw(currentGameTime, spriteBatch);

            for (int i = 0; i < mRoomUnselected.Length; ++i)
                mRoomUnselected[i].Draw(currentGameTime, spriteBatch);

            mRoomSelected.Draw(currentGameTime, spriteBatch);

            if (mNPC != null)
                mNPC.Draw(currentGameTime, spriteBatch);

            mLifeBar.Draw(currentGameTime, spriteBatch);
            mEatBar.Draw(currentGameTime, spriteBatch);
            mSleepBar.Draw(currentGameTime, spriteBatch);
            mRelieveBar.Draw(currentGameTime, spriteBatch);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void SelectRoom()
        {
            // Argh. TODO: Improve this. Would be better to not depend on NPC state
            switch (mNPC.GetState())
            {
                case GameNPCStates.NPC_STATE_WORKING:
                    mRoomSelected.SetPosition(0.0f, GameLevelTutorialConstants.ROOM_SELECTION_Y);
                    mRoomUnselected[0].SetPosition(mRoomSelected.GetWidth(), GameLevelTutorialConstants.ROOM_SELECTION_Y);
                    mRoomUnselected[1].SetPosition(mRoomSelected.GetWidth() * 2, GameLevelTutorialConstants.ROOM_SELECTION_Y);
                    mRoomUnselected[2].SetPosition(mRoomSelected.GetWidth() * 3, GameLevelTutorialConstants.ROOM_SELECTION_Y);
                    break;

                case GameNPCStates.NPC_STATE_RELIEVING:
                    mRoomSelected.SetPosition(mRoomSelected.GetWidth(), GameLevelTutorialConstants.ROOM_SELECTION_Y);
                    mRoomUnselected[0].SetPosition(0, GameLevelTutorialConstants.ROOM_SELECTION_Y);
                    mRoomUnselected[1].SetPosition(mRoomSelected.GetWidth() * 2, GameLevelTutorialConstants.ROOM_SELECTION_Y);
                    mRoomUnselected[2].SetPosition(mRoomSelected.GetWidth() * 3, GameLevelTutorialConstants.ROOM_SELECTION_Y);
                    break;

                case GameNPCStates.NPC_STATE_SLEEPING:
                    mRoomSelected.SetPosition(mRoomSelected.GetWidth() * 2, GameLevelTutorialConstants.ROOM_SELECTION_Y);
                    mRoomUnselected[0].SetPosition(0.0f, GameLevelTutorialConstants.ROOM_SELECTION_Y);
                    mRoomUnselected[1].SetPosition(mRoomSelected.GetWidth(), GameLevelTutorialConstants.ROOM_SELECTION_Y);
                    mRoomUnselected[2].SetPosition(mRoomSelected.GetWidth() * 3, GameLevelTutorialConstants.ROOM_SELECTION_Y);
                    break;

                case GameNPCStates.NPC_STATE_EATING:
                    mRoomSelected.SetPosition(mRoomSelected.GetWidth() * 3, GameLevelTutorialConstants.ROOM_SELECTION_Y);
                    mRoomUnselected[0].SetPosition(0, GameLevelTutorialConstants.ROOM_SELECTION_Y);
                    mRoomUnselected[1].SetPosition(mRoomSelected.GetWidth(), GameLevelTutorialConstants.ROOM_SELECTION_Y);
                    mRoomUnselected[2].SetPosition(mRoomSelected.GetWidth() * 2, GameLevelTutorialConstants.ROOM_SELECTION_Y);
                    break;
            }
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void OnEnter()
        {
            base.OnEnter();

            Debug.Log(Debug.Flags.DEBUG_LEVELS, "");
            Debug.Log(Debug.Flags.DEBUG_LEVELS, "#################################");
            Debug.Log(Debug.Flags.DEBUG_LEVELS, "   GameLevelTutorial.OnEnter()   ");
            Debug.Log(Debug.Flags.DEBUG_LEVELS, "#################################");
            Debug.Log(Debug.Flags.DEBUG_LEVELS, "");
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void OnChildMessage()
        {
            SelectRoom();
        }
    }
}
