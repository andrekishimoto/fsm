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
    // GameNPC_TechSlave
    //
    // A tech slave NPC - all he does is work, work, eat, number 2, sleep, work
    //-----------------------------------------------------------------------------
    public class GameNPC_TechSlave : GameNPC
    {
        protected GameLevel mParent;

        protected float mLifeCounter;
        protected float mEatCounter;
        protected float mSleepCounter;
        protected float mRelieveCounter;

        protected GameNPCStates mState;

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameNPC_TechSlave(EntityID id, GameLevel parent)
            : base(id)
        {
            mParent = parent;
            mType = GameObjectType.GAME_OBJECT_NPC_TECH_SLAVE;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Construct(Texture2D sprite, Vector2 position)
        {
            base.Construct(sprite, position);

            mLifeCounter = GameNPCConstants.NPC_TECH_SLAVE_INITIAL_LIFE;
            mEatCounter = 0.0f;
            mSleepCounter = 0.0f;
            mRelieveCounter = 0.0f;

            mUpdateWaitMilliseconds = GameNPCConstants.NPC_TECH_SLAVE_UPDATE_DELAY_MILLISECONDS;

            mFSM.SetGlobalState(GameNPCStateGlobal.Instance());

            SetState(GameNPCStates.NPC_STATE_WORKING);
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
        public GameNPCStates GetState()
        {
            return mState;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void SetState(GameNPCStates state)
        {
            mState = state;

            switch (state)
            {
                case GameNPCStates.NPC_STATE_IDLE:
                    mFSM.SetState(GameNPCStateIdle.Instance());
                    break;

                case GameNPCStates.NPC_STATE_WORKING:
                    mFSM.SetState(GameNPCStateWorking.Instance());
                    break;

                case GameNPCStates.NPC_STATE_EATING:
                    mFSM.SetState(GameNPCStateEating.Instance());
                    break;

                case GameNPCStates.NPC_STATE_SLEEPING:
                    mFSM.SetState(GameNPCStateSleeping.Instance());
                    break;

                case GameNPCStates.NPC_STATE_RELIEVING:
                    mFSM.SetState(GameNPCStateRelieving.Instance());
                    break;

                case GameNPCStates.NPC_STATE_DEAD:
                    mFSM.SetState(GameNPCStateDead.Instance());
                    break;
            }

            // TODO: Make it more generic and better (currently only good for this particular example)
            mParent.OnChildMessage();
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
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public bool IsDead()
        {
            return mLifeCounter <= 0.0f;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public float GetLifeCounter()
        {
            return mLifeCounter;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public float GetEatCounter()
        {
            return mEatCounter;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public float GetSleepCounter()
        {
            return mSleepCounter;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public float GetRelieveCounter()
        {
            return mRelieveCounter;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void AddToLifeCounter(float value)
        {
            mLifeCounter += value;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void AddToEatCounter(float value)
        {
            mEatCounter += value;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void AddToSleepCounter(float value)
        {
            mSleepCounter += value;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void AddToRelieveCounter(float value)
        {
            mRelieveCounter += value;
        }
    }
}
