using UnityEngine;
using EnemyState;


public class EnemyController : MonoBehaviour
{
    //変更前のステート名
    protected string _beforeStateName;
    //ステート
    public StateProcessor stateProcessor = new StateProcessor();
    public BreakState breakState = new BreakState();

    // Start is called before the first frame update
    virtual protected void Start()
    {
        //デリゲートへBreakセット
        breakState.execDelegate = Break;
    }
    // Update is called once per frame
    void Update()
    {
        //stateがnullの場合は処理しないまたはEnemyが死亡している場合は処理しない
        if (stateProcessor.State == null || breakState.breakType == 1)
        {
            return;
        }
        //前回実行ステータスと今回実行ステータスが同じではない または　ContinueTypeが1の場合
        if (_beforeStateName != stateProcessor.State.getStateName()　|| stateProcessor.State.ContinueType == 1)
        {
            //現在のステート名を格納
            _beforeStateName = stateProcessor.State.getStateName();
            //現在格納されているステートのデリゲートを実行する
            stateProcessor.Execute();
        }
    }

    //stateがbreakになった場合
    virtual protected void Break()
    {
        //breaktypeを1(破壊)に変更
        breakState.breakType = 1;
    }

    //現在のステートをブレイクに変更
    public void ChangeStateBreak()
    {
        stateProcessor.State = breakState;
    }
}
