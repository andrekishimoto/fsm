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
    // GameBar
    //
    // Game bar (1x1 texture that will scale during Draw())
    // TODO: Create 1x1 texture via code. We don't need to use external PNGs
    // since it's a simple 1 pixel color.
    //-----------------------------------------------------------------------------
    public class GameBar : GameObject
    {
        protected Vector2 mScaleFactor;

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameBar(EntityID id)
            : base(id)
        {
            mType = GameObjectType.GAME_OBJECT_BAR;

            mScaleFactor = Vector2.One;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void SetScaleFactor(Vector2 scaleFactor)
        {
            mScaleFactor = scaleFactor;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void SetScaleFactorX(float x)
        {
            mScaleFactor.X = x;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void SetScaleFactorY(float y)
        {
            mScaleFactor.Y = y;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void IncreaseScaleFactorXBy(float amount)
        {
            mScaleFactor.X += amount;
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
            if (mSprite != null)
            {
                spriteBatch.Draw(mSprite,
                    mPosition,
                    null,
                    Color.White,
                    0.0f, // Rotation
                    Vector2.Zero, // Origin
                    mScaleFactor,
                    SpriteEffects.None,
                    0.0f);
            }
        }
    }
}
