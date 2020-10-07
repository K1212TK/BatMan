using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerState 
{

    //  下記プレイヤー状態クラス

    //  立ち状態
    public class StandState : State
    {
        public StandState()
        {
            ContinueType = 0;
        }
        public override string getStateName()
        {
            return "stand";
        }
        public override int getStateType()
        {
            return 0;
        }
    }

    //左移動状態
    public class LeftRunState : State
    {
        public LeftRunState()
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

    //右移動状態
    public class RightRunState : State
    {
        public RightRunState()
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


    //ジャンプ状態
    public class JumpState : State
    {
        public JumpState()
        {
            ContinueType = 0;
        }
        public override string getStateName()
        {
            return "jump";
        }
        public override int getStateType()
        {
            return 2;
        }
    }

    //攻撃状態
    public class AttackState : State
    {
        public AttackState()
        {
            ContinueType = 0;
        }

        public override string getStateName()
        {
            return "attack";
        }
        public override int getStateType()
        {
            return 3;
        }
    }

    //ダウン状態
    public class DownState : State
    {
        public DownState()
        {
            ContinueType = 1;
        }

        public override string getStateName()
        {
            return "down";
        }
        public override int getStateType()
        {
            return 4;
        }
    }
}
