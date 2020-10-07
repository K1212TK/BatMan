using PlayerState;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //プレイヤーの情報をインスペクターから取得
    public Player player;
    //アニメーションの情報をインスペクターから取得
    public PlayerAnimationManager animationManager;
    //サウンドマネージャーの情報をインスペクターから取得
    public SoundManager soundManager;

    //変更前のステート名
    private string _beforeStateName;
    //各ステータスのインスタンスを生成
    public StateProcessor stateProcessor = new StateProcessor();
    public StandState standState = new StandState();
    public LeftRunState leftRunState = new LeftRunState();
    public RightRunState rightRunState = new RightRunState();
    public JumpState jumpState = new JumpState();
    public AttackState attackState = new AttackState();
    public DownState downState = new DownState();

    // Use this for initialization
    void Start()
    {
        //初期ステータス
        stateProcessor.State = standState;
        //立ちステータスをデリゲートへセット
        standState.execDelegate = Stand;
        //左走りステータスをデリゲートへセット
        leftRunState.execDelegate = LeftRun;
        //右走りステータスをデリゲートへセット
        rightRunState.execDelegate = RightRun;
        //ジャンプステータスをデリゲートへセット
        jumpState.execDelegate = Jump;
        //攻撃ステータスをデリゲートへセット
        attackState.execDelegate = Attack;
        //ダウンステータスをデリゲートへセット
        downState.execDelegate = Down;
    }

    // Update is called once per frame
    void Update()
    {
        //stateがnullの場合は処理しない
        if (stateProcessor.State == null)
        {
            return;
        }
        //現在のステータスと格納されたステータスの差分があった場合実行 繰り返し実行するものは繰り返す
        if (stateProcessor.State.getStateName() != _beforeStateName || stateProcessor.State.ContinueType == 1)
        {
            //前回のステータスから現在のステータスへ書き換え
            _beforeStateName = stateProcessor.State.getStateName();
            //現在格納されているステートのデリゲートを実行する
            stateProcessor.Execute();
        }
    }

    //ステート名を返す
    public string GetStateName()
    {
        return _beforeStateName;
    }

    //ステータスがstandになったら実行される
    private void Stand()
    {
        //実行中のアニメーションを止める
        animationManager.SetFalseAllAnimation();
        //立ち状態で行う処理の記述
        player.StopMove();
    }

    //ステータスがleftRunになったら実行される
    private void LeftRun()
    {
        //アニメーションを歩きに変更する
        animationManager.SetTrueAnimation(stateProcessor.State.getStateType());
        //左走り状態で行う処理の記述
        player.MoveLeft();
    }

    //ステータスがrightRunになったら実行される
    private void RightRun()
    {
        //アニメーションを歩きに変更する
        animationManager.SetTrueAnimation(stateProcessor.State.getStateType());
        //右歩き状態で行う処理の記述
        player.MoveRight();
    }

    //ステータスがjumpになったら実行される
    private void Jump()
    {
        //プレイヤーが地面に触れていた場合
        if (player.dacision.IsGround()　
            || player.dacision.IsParts() 
            || player.dacision.IsFallGround() 
            || player.dacision.IsBlock())
        {
            //アニメーションをジャンプに変更する
            animationManager.SetTrueAnimation(stateProcessor.State.getStateType());
            //ジャンプ状態で行う処理の記述
            player.MoveJump();
        }
    }

    //ステータスが攻撃になったら実行される
    private void Attack()
    {
        //SEの再生
        soundManager.PlayAttackSound();
        //アニメーションを攻撃に変更する
        animationManager.SetTrueAnimation(stateProcessor.State.getStateType());
    }

    //ステータスがダウンになったら呼び出す
    private void Down()
    {
        //ダウン時のSE再生
        soundManager.PlayDownSound();
        //アニメーションをダウンに変更する
        animationManager.SetTrueAnimation(stateProcessor.State.getStateType());
        //ダウン状態で行う処理の記述
        player.MoveDown();
        //残機を減らす
        GManager.instance.RemoveLife();
    }


    //ジャンプボタンが押されたら呼び出し 
    //ステートをジャンプに変更する
    public void ChangeStateJump()
    {
        //現在のステートをジャンプに変更する
        stateProcessor.State = jumpState;
    }

    //何も入力がない場合呼び出し
    //ステートを立ちに変更する
    public void ChangeStateStand()
    {
        //現在のステータスを立ちに変更
        stateProcessor.State = standState;
        
    }

    //左移動ボタン入力時呼び出し
    //ステートを走りに変更
    public void ChangeStateLeftRun()
    {
        //現在のステータスを左走りに変更
        stateProcessor.State = leftRunState;
    }

    //左移動ボタン入力時呼び出し
    //ステートを走りに変更
    public void ChangeStateRightRun()
    {
        //現在のステータスを右走りに変更
        stateProcessor.State = rightRunState;
    }

    //攻撃ボタン入力時呼び出し
    //ステートを走りに変更
    public void ChangeStateAttack()
    {
        //現在のステータスを攻撃に変更
        stateProcessor.State = attackState;
    }

    //ダウン時呼び出し
    //ステートをダウンに変更
    public void ChangeStateDown()
    {
        //現在のステータスを攻撃に変更
        stateProcessor.State = downState;
    }
}