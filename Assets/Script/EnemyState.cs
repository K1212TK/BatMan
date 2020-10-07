using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyState 
{
    //  下記エネミー状態クラス

    //移動状態
    public class RunState : State
    {
        public RunState()
        {
            ContinueType = 1;
        }

        public override string getStateName()
        {
            return "run";
        }
        public override int getStateType()
        {
            return 1;
        }
    }

    //ブレイク状態
    public class BreakState : State
    {
        //0:生存　1:死亡
        public int breakType = 0;

        public BreakState()
        {
            ContinueType = 0;
        }

        public override string getStateName()
        {
            return "break";
        }
        public override int getStateType()
        {
            return 2;
        }
    }

    //ジャンプ状態
    public class JumpState : State
    {
        public JumpState()
        {
            ContinueType = 1;
        }

        public override string getStateName()
        {
            return "jump";
        }

        public override int getStateType()
        {
            return 3;
        }
    }

}
