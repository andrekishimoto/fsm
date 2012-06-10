//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // StateMachine
    //
    // Responsible for maintaining the object's state and transitions
    // Game objects should instantiated this class
    //-----------------------------------------------------------------------------
    public class StateMachine
    {
        private Object mParent;

        private float mUpdateWaitMilliseconds;
        private TimeSpan mPreviousGameTime;

        protected IState mCurrentState;
        protected IState mPreviousState;

        protected IState mGlobalState;
        protected IState mPreviousGlobalState;

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public StateMachine(Object parent, float updateWaitMilliseconds, IState initialState)
        {
            mParent = parent;

            mUpdateWaitMilliseconds = updateWaitMilliseconds;
            mPreviousGameTime = TimeSpan.Zero;

            mCurrentState = initialState;
            mPreviousState = null;

            mGlobalState = null;
            mPreviousGlobalState = null;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void Destroy()
        {
            mParent = null;

            mCurrentState = null;
            mPreviousState = null;

            mGlobalState = null;
            mPreviousGlobalState = null;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public IState GetState()
        {
            return mCurrentState;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public IState GetPreviousState()
        {
            return mPreviousState;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public IState GetGlobalState()
        {
            return mGlobalState;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public IState GetPreviousGlobalState()
        {
            return mPreviousGlobalState;
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
        public void ClearCurrentState()
        {
            mCurrentState = null;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void SetState(IState state)
        {
            if (state == null)
            {
                Debug.Log(Debug.Flags.DEBUG_STATE_MACHINE, "[ERROR] StateMachine.SetState() called with null state.");
                return;
            }

            if (state == mCurrentState)
            {
                Debug.Log(Debug.Flags.DEBUG_STATE_MACHINE, "[ERROR] StateMachine.SetState() called with state equal to mCurrentState.");
                return;
            }

            mPreviousState = mCurrentState;

            if (mCurrentState != null)
                mCurrentState.Exit(ref mParent);

            mCurrentState = state;
            mCurrentState.Enter(ref mParent);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void SetGlobalState(IState globalState)
        {
            if (globalState == null)
            {
                Debug.Log(Debug.Flags.DEBUG_STATE_MACHINE, "[ERROR] StateMachine.SetGlobalState() called with null state.");
                return;
            }

            if (globalState == mGlobalState)
            {
                Debug.Log(Debug.Flags.DEBUG_STATE_MACHINE, "[ERROR] StateMachine.SetGlobalState() called with state equal to mGlobalState.");
                return;
            }

            mPreviousGlobalState = mGlobalState;

            if (mGlobalState != null)
                mGlobalState.Exit(ref mParent);

            mGlobalState = globalState;
            mGlobalState.Enter(ref mParent);
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void RevertToPreviousState()
        {
            SetState(mPreviousState);
            mPreviousState = null;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void RevertToPreviousGlobalState()
        {
            SetGlobalState(mPreviousGlobalState);
            mPreviousGlobalState = null;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public void Update(TimeSpan currentGameTime)
        {
            if (Utils.MustSkipFrame(mUpdateWaitMilliseconds, currentGameTime, mPreviousGameTime))
                return;

            if (mGlobalState != null)
                mGlobalState.Update(ref mParent, currentGameTime);

            if (mCurrentState != null)
                mCurrentState.Update(ref mParent, currentGameTime);

            mPreviousGameTime = currentGameTime;
        }
    }
}
