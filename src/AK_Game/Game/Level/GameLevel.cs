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
    // GameLevel
    //
    // Base game level
    //-----------------------------------------------------------------------------
    public class GameLevel : GameEntity
    {
        protected GameLevelType mType;

        protected GuiScreen mParent;
        protected ContentManager mContentManager;

        protected float mUpdateWaitMilliseconds;
        protected TimeSpan mPreviousGameTime;

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameLevel(EntityID id, GuiScreen parent, ContentManager contentManager)
            : base(id)
        {
            mType = GameLevelType.LEVEL_DEFAULT;
            InitializeMembers(parent, contentManager);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameLevel(EntityID id, GameLevelType type, GuiScreen parent, ContentManager contentManager)
            : base(id)
        {
            mType = type;
            InitializeMembers(parent, contentManager);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        protected virtual void InitializeMembers(GuiScreen parent, ContentManager contentManager)
        {
            mParent = parent;
            mContentManager = contentManager;

            mUpdateWaitMilliseconds = 0.0f;
            mPreviousGameTime = TimeSpan.Zero;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void Construct()
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void Destroy()
        {
            mParent = null;
            mContentManager = null;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void SetGameLevelType(GameLevelType type)
        {
            mType = type;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameLevelType GetGameLevelType()
        {
            return mType;
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
            if (Utils.MustSkipFrame(mUpdateWaitMilliseconds, currentGameTime, mPreviousGameTime))
                return;

            mPreviousGameTime = currentGameTime;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void Draw(TimeSpan currentGameTime, SpriteBatch spriteBatch)
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void OnEnter()
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        // TODO: Make it more generic and better (currently only good for this
        // particular example). Apply Observer pattern?
        public virtual void OnChildMessage()
        {
        }
    }
}
