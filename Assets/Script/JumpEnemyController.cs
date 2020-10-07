using EnemyState;

//ジャンプする敵を制御するコントローラー
public class JumpEnemyController : EnemyController
{
    //インスペクターから設定
    public JumpEnemy enemy;    
    //ジャンプステータス
    public JumpState jumpState = new JumpState();

    // Start is called before the first frame update
    override protected void Start()
    {
        //ベースクラスのStart呼び出し
        base.Start();
        //デリゲートへJumpメソッドをセット
        jumpState.execDelegate = Jump;
    }

    override protected void Break()
    {
        base.Break();
        enemy.BreakEnemy();
    }

    //ジャンプ時の処理
    private void Jump()
    {
        //敵をジャンプさせる
        enemy.JumpingEnemy();
    }

    //ステータスをジャンプに変更する
    public void ChangeStateJump()
    {
        if (ReferenceEquals(stateProcessor.State, breakState))
        {
            return;
        }
        //jumpStateをセット
        stateProcessor.State = jumpState;
    }
}
