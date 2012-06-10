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
    // GameNPC
    //
    // Base NPC
    //-----------------------------------------------------------------------------
    public class GameNPC : GameObject
    {
        protected StateMachine mFSM;

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameNPC(EntityID id)
            : base(id)
        {
            mType = GameObjectType.GAME_OBJECT_NPC;
            
            mFSM = null;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Construct(Texture2D sprite, Vector2 position)
        {
            base.Construct(sprite, position);

            mFSM = new StateMachine(this, GameNPCConstants.NPC_UPDATE_DELAY_MILLISECONDS, null);
            SetState(GameNPCStates.NPC_STATE_IDLE);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Destroy()
        {
            if (mFSM != null)
            {
                mFSM.Destroy();
                mFSM = null;
            }

            base.Destroy();
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public virtual void SetState(GameNPCStates state)
        {
            switch (state)
            {
                case GameNPCStates.NPC_STATE_IDLE:
                    mFSM.SetState(GameNPCStateIdle.Instance());
                    break;
            }
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(TimeSpan currentGameTime)
        {
            mFSM.Update(currentGameTime);

            base.Update(currentGameTime);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Draw(TimeSpan currentGameTime, SpriteBatch spriteBatch)
        {
            base.Draw(currentGameTime, spriteBatch);
        }
    }
}
