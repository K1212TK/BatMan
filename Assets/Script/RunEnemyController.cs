using EnemyState;
using System.Diagnostics;

//歩く敵を制御するコントローラー
public class RunEnemyController : EnemyController
{
    //インスペクターから設定
    public RunEnemy enemy;
    //runステータス
    public RunState runState = new RunState();

    // Start is called before the first frame update
    override protected void Start()
    {
        //ベースクラスのStart呼び出し
        base.Start();
        //デリゲートへRunメソッドセット
        runState.execDelegate = Run;
        //デフォルトのステートをセット
        //stateProcessor.State = runState;
    }

    override protected void Break()
    {
        base.Break();
        enemy.BreakEnemy();
    }

    //stateが走りになった場合
    private void Run()
    {
        //Enemyを走らせる
        enemy.RunningEnemy();
    }

    //現在のステートを走りに変更
    public void ChangeStateRun()
    {
        if (ReferenceEquals(stateProcessor.State, breakState))
        {
            return;
        }
        stateProcessor.State = runState;
    }
}
