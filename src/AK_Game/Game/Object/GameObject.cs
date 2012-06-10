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
    // GameObject
    //
    // Base class for all game objects in the game
    //-----------------------------------------------------------------------------
    public class GameObject : GameEntity
    {
        protected GameObjectType mType;

        protected Texture2D mSprite;
        protected Vector2 mPosition;

        protected float mUpdateWaitMilliseconds;
        protected TimeSpan mPreviousGameTime;

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameObject(EntityID id)
            : base(id)
        {
            mType = GameObjectType.GAME_OBJECT_DEFAULT;

            mSprite = null;
            mPosition = Vector2.Zero;

            mUpdateWaitMilliseconds = 0.0f;
            mPreviousGameTime = TimeSpan.Zero;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void Construct(Texture2D sprite, Vector2 position)
        {
            mSprite = sprite;
            mPosition = position;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void Destroy()
        {
            mSprite = null;
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
        public GameObjectType GetGameObjectType()
        {
            return mType;
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
        public void SetPosition(Vector2 position)
        {
            mPosition = position;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void SetPosition(float x, float y)
        {
            mPosition.X = x;
            mPosition.Y = y;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public int GetWidth()
        {
            return mSprite.Width;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public int GetHeight()
        {
            return mSprite.Height;
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
            if (mSprite != null)
                spriteBatch.Draw(mSprite, mPosition, Color.White);
        }
    }
}
