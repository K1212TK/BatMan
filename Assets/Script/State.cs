using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;


//ステートのクラス
public abstract class State
{
    //デリゲート
    public delegate void executeState();
    public executeState execDelegate;

    //繰り返し実行するか否か
    private int _ContinueType;
    public int ContinueType
    {
        protected set { _ContinueType = value; }
        get { return _ContinueType; }
    }

    //実行処理
    public virtual void Execute()
    {
        if (execDelegate != null)
        {
            execDelegate();
        }
    }

    //ステート名を取得するメソッド
    public abstract string getStateName();
    //ステートタイプを取得するメソッド
    public abstract int getStateType();
}