//-----------------------------------------------------------------------------
// FSM Implementation
// (c) 2012, André Kishimoto
//-----------------------------------------------------------------------------

using System;

namespace AK_Game
{
    //-----------------------------------------------------------------------------
    // GameNPCStates
    //
    // States of a NPC
    //-----------------------------------------------------------------------------
    public enum GameNPCStates
    {
        NPC_STATE_IDLE = 0,
        NPC_STATE_WORKING,
        NPC_STATE_EATING,
        NPC_STATE_SLEEPING,
        NPC_STATE_RELIEVING,
        NPC_STATE_DEAD
    }

    //
    // TODO: All these states work only for this particular example
    //

    //-----------------------------------------------------------------------------
    // GameNPCStateGlobal
    //
    // NPC state: Global
    //-----------------------------------------------------------------------------
    public class GameNPCStateGlobal : IState
    {
        // Singleton
        private static GameNPCStateGlobal mInstance = null;
        public static GameNPCStateGlobal Instance()
        {
            if (mInstance == null)
                mInstance = new GameNPCStateGlobal();
            return mInstance;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameNPCStateGlobal()
            : base()
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Enter(ref Object owner)
        {
            //GameNPC npc = (GameNPC)owner;
            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateGlobal.Enter()", npc.GetGameObjectType());
            
            Debug.Log(Debug.Flags.DEBUG_NPC, "Estou entrando no estado Global.");
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(ref Object owner, TimeSpan currentGameTime)
        {
            GameNPC npc = (GameNPC)owner;
            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateGlobal.Update()", npc.GetGameObjectType());

            if (npc.GetGameObjectType() == GameObjectType.GAME_OBJECT_NPC_TECH_SLAVE)
            {
                GameNPC_TechSlave npcTechSlave = (GameNPC_TechSlave)npc;

                if (!npcTechSlave.IsDead())
                {
                    npcTechSlave.AddToLifeCounter(GameNPCConstants.NPC_LIFE_UPDATE_AMOUNT);

                    if (npcTechSlave.GetLifeCounter() <= GameNPCConstants.NPC_LIFE_TRIGGER_AMOUNT)
                        npcTechSlave.SetState(GameNPCStates.NPC_STATE_DEAD);

                    if (npcTechSlave.GetRelieveCounter() >= GameNPCConstants.NPC_RELIEVE_TRIGGER_AMOUNT)
                        npcTechSlave.SetState(GameNPCStates.NPC_STATE_RELIEVING);
                }
            }
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Exit(ref Object owner)
        {
            //GameNPC npc = (GameNPC)owner;
            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateGlobal.Exit()", npc.GetGameObjectType());

            Debug.Log(Debug.Flags.DEBUG_NPC, "Estou saindo do estado Global.");
        }
    }

    //-----------------------------------------------------------------------------
    // GameNPCStateIdle
    //
    // NPC state: Idle
    //-----------------------------------------------------------------------------
    public class GameNPCStateIdle : IState
    {
        // Singleton
        private static GameNPCStateIdle mInstance = null;
        public static GameNPCStateIdle Instance()
        {
            if (mInstance == null)
                mInstance = new GameNPCStateIdle();
            return mInstance;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameNPCStateIdle()
            : base()
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Enter(ref Object owner)
        {
            //GameNPC npc = (GameNPC)owner;
            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateIdle.Enter()", npc.GetGameObjectType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(ref Object owner, TimeSpan currentGameTime)
        {
            //GameNPC npc = (GameNPC)owner;
            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateIdle.Update()", npc.GetGameObjectType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Exit(ref Object owner)
        {
            //GameNPC npc = (GameNPC)owner;
            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateIdle.Exit()", npc.GetGameObjectType());
        }
    }

    //-----------------------------------------------------------------------------
    // GameNPCStateWorking
    //
    // NPC state: Working
    //-----------------------------------------------------------------------------
    public class GameNPCStateWorking : IState
    {
        // Singleton
        private static GameNPCStateWorking mInstance = null;
        public static GameNPCStateWorking Instance()
        {
            if (mInstance == null)
                mInstance = new GameNPCStateWorking();
            return mInstance;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameNPCStateWorking()
            : base()
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Enter(ref Object owner)
        {
            GameNPC npc = (GameNPC)owner;

            npc.SetPosition(((Constants.SCREEN_WIDTH/4 - npc.GetWidth()) >> 1) - npc.GetWidth(),
                (Constants.SCREEN_HEIGHT - npc.GetHeight() - (npc.GetHeight() >> 3)));

            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateWorking.Enter()", npc.GetGameObjectType());
            Debug.Log(Debug.Flags.DEBUG_NPC, "Voltando pro trabalho escravo...");
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(ref Object owner, TimeSpan currentGameTime)
        {
            GameNPC npc = (GameNPC)owner;

            if (npc.GetGameObjectType() == GameObjectType.GAME_OBJECT_NPC_TECH_SLAVE)
            {
                GameNPC_TechSlave npcTechSlave = (GameNPC_TechSlave)npc;

                npcTechSlave.AddToEatCounter(GameNPCConstants.NPC_EAT_UPDATE_AMOUNT);
                npcTechSlave.AddToSleepCounter(GameNPCConstants.NPC_SLEEP_UPDATE_AMOUNT);

                if (npcTechSlave.GetEatCounter() >= GameNPCConstants.NPC_EAT_TRIGGER_AMOUNT)
                    npcTechSlave.SetState(GameNPCStates.NPC_STATE_EATING);

                if (npcTechSlave.GetSleepCounter() >= GameNPCConstants.NPC_SLEEP_TRIGGER_AMOUNT)
                    npcTechSlave.SetState(GameNPCStates.NPC_STATE_SLEEPING);
            }

            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateWorking.Update()", npc.GetGameObjectType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Exit(ref Object owner)
        {
            //GameNPC npc = (GameNPC)owner;
            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateWorking.Exit()", npc.GetGameObjectType());
            
            Debug.Log(Debug.Flags.DEBUG_NPC, "Preciso fazer outra coisa alem de trabalhar!");
        }
    }

    //-----------------------------------------------------------------------------
    // GameNPCStateEating
    //
    // NPC state: Eating
    //-----------------------------------------------------------------------------
    public class GameNPCStateEating : IState
    {
        // Singleton
        private static GameNPCStateEating mInstance = null;
        public static GameNPCStateEating Instance()
        {
            if (mInstance == null)
                mInstance = new GameNPCStateEating();
            return mInstance;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameNPCStateEating()
            : base()
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Enter(ref Object owner)
        {
            GameNPC npc = (GameNPC)owner;
            npc.SetPosition(((Constants.SCREEN_WIDTH / 4 - npc.GetWidth()) >> 1) + Constants.SCREEN_WIDTH / 4 * 3 - npc.GetWidth(),
                (Constants.SCREEN_HEIGHT - npc.GetHeight() - (npc.GetHeight() >> 3)));

            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateEating.Enter()", npc.GetGameObjectType());
            Debug.Log(Debug.Flags.DEBUG_NPC, "Um lanche agora nao ia ser nada mal.");
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(ref Object owner, TimeSpan currentGameTime)
        {
            GameNPC npc = (GameNPC)owner;

            if (npc.GetGameObjectType() == GameObjectType.GAME_OBJECT_NPC_TECH_SLAVE)
            {
                GameNPC_TechSlave npcTechSlave = (GameNPC_TechSlave)npc;
                npcTechSlave.AddToEatCounter(GameNPCConstants.NPC_EAT_INSIDE_UPDATE_AMOUNT);
                npcTechSlave.AddToRelieveCounter(GameNPCConstants.NPC_RELIEVE_UPDATE_AMOUNT);

                if (npcTechSlave.GetEatCounter() <= 0.0f)
                    npcTechSlave.SetState(GameNPCStates.NPC_STATE_WORKING);
            }

            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateEating.Update()", npc.GetGameObjectType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Exit(ref Object owner)
        {
            //GameNPC npc = (GameNPC)owner;
            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateEating.Exit()", npc.GetGameObjectType());
            
            Debug.Log(Debug.Flags.DEBUG_NPC, "Ja estou satisfeito.");
        }
    }

    //-----------------------------------------------------------------------------
    // GameNPCStateSleeping
    //
    // NPC state: Sleeping
    //-----------------------------------------------------------------------------
    public class GameNPCStateSleeping : IState
    {
        // Singleton
        private static GameNPCStateSleeping mInstance = null;
        public static GameNPCStateSleeping Instance()
        {
            if (mInstance == null)
                mInstance = new GameNPCStateSleeping();
            return mInstance;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameNPCStateSleeping()
            : base()
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Enter(ref Object owner)
        {
            GameNPC npc = (GameNPC)owner;
            npc.SetPosition(((Constants.SCREEN_WIDTH / 4 - npc.GetWidth()) >> 1) + Constants.SCREEN_WIDTH / 4 * 2 - npc.GetWidth(),
                (Constants.SCREEN_HEIGHT - npc.GetHeight() - (npc.GetHeight() >> 3)));

            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateSleeping.Enter()", npc.GetGameObjectType());
            Debug.Log(Debug.Flags.DEBUG_NPC, "Dormir um pouco porque ninguem e' de ferro, ne?");
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(ref Object owner, TimeSpan currentGameTime)
        {
            GameNPC npc = (GameNPC)owner;

            if (npc.GetGameObjectType() == GameObjectType.GAME_OBJECT_NPC_TECH_SLAVE)
            {
                GameNPC_TechSlave npcTechSlave = (GameNPC_TechSlave)npc;
                npcTechSlave.AddToSleepCounter(GameNPCConstants.NPC_SLEEP_INSIDE_UPDATE_AMOUNT);

                if (npcTechSlave.GetSleepCounter() <= 0.0f)
                    //npcTechSlave.SetSleepCounter(0.0f);
                    npcTechSlave.SetState(GameNPCStates.NPC_STATE_WORKING);
            }

            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateSleeping.Update()", npc.GetGameObjectType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Exit(ref Object owner)
        {
            //GameNPC npc = (GameNPC)owner;
            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateSleeping.Exit()", npc.GetGameObjectType());

            Debug.Log(Debug.Flags.DEBUG_NPC, "zZzZz... Argh, odeio acordar...");
        }
    }

    //-----------------------------------------------------------------------------
    // GameNPCStateRelieving
    //
    // NPC state: GameNPCStateRelieving
    //-----------------------------------------------------------------------------
    public class GameNPCStateRelieving : IState
    {
        // Singleton
        private static GameNPCStateRelieving mInstance = null;
        public static GameNPCStateRelieving Instance()
        {
            if (mInstance == null)
                mInstance = new GameNPCStateRelieving();
            return mInstance;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameNPCStateRelieving()
            : base()
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Enter(ref Object owner)
        {
            GameNPC npc = (GameNPC)owner;
            npc.SetPosition(((Constants.SCREEN_WIDTH / 4 - npc.GetWidth()) >> 1) + Constants.SCREEN_WIDTH / 4 - npc.GetWidth(),
                (Constants.SCREEN_HEIGHT - npc.GetHeight() - (npc.GetHeight() >> 3)));

            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateRelieving.Enter()", npc.GetGameObjectType());
            Debug.Log(Debug.Flags.DEBUG_NPC, "Numero 2, aqui vou eu!");
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(ref Object owner, TimeSpan currentGameTime)
        {
            GameNPC npc = (GameNPC)owner;

            if (npc.GetGameObjectType() == GameObjectType.GAME_OBJECT_NPC_TECH_SLAVE)
            {
                GameNPC_TechSlave npcTechSlave = (GameNPC_TechSlave)npc;
                npcTechSlave.AddToRelieveCounter(GameNPCConstants.NPC_RELIEVE_INSIDE_UPDATE_AMOUNT);

                if (npcTechSlave.GetRelieveCounter() <= 0.0f)
                    //npcTechSlave.SetRelieveCounter(0.0f);
                    npcTechSlave.SetState(GameNPCStates.NPC_STATE_WORKING);
            }

            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateRelieving.Update()", npc.GetGameObjectType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Exit(ref Object owner)
        {
            //GameNPC npc = (GameNPC)owner;
            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateRelieving.Exit()", npc.GetGameObjectType());

            Debug.Log(Debug.Flags.DEBUG_NPC, "Nossa, preciso comprar um Bom Ar!");
        }
    }

    //-----------------------------------------------------------------------------
    // GameNPCStateDead
    //
    // NPC state: GameNPCStateDead
    //-----------------------------------------------------------------------------
    public class GameNPCStateDead : IState
    {
        // Singleton
        private static GameNPCStateDead mInstance = null;
        public static GameNPCStateDead Instance()
        {
            if (mInstance == null)
                mInstance = new GameNPCStateDead();
            return mInstance;
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public GameNPCStateDead()
            : base()
        {
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Enter(ref Object owner)
        {
            //GameNPC npc = (GameNPC)owner;
            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateDead.Enter()", npc.GetGameObjectType());

            Debug.Log(Debug.Flags.DEBUG_NPC, "R.I.P.");
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Update(ref Object owner, TimeSpan currentGameTime)
        {
            //GameNPC npc = (GameNPC)owner;
            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateDead.Update()", npc.GetGameObjectType());
        }

        //-----------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------
        public override void Exit(ref Object owner)
        {
            //GameNPC npc = (GameNPC)owner;
            //Debug.Log(Debug.Flags.DEBUG_NPC, "[ {0} ] GameNPCStateDead.Exit()", npc.GetGameObjectType());
        }
    }
}
