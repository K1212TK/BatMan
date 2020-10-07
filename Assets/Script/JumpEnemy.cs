using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemy : Enemy
{
    //Jumpする敵のコントローラー
    public JumpEnemyController controller;
    [Header("jump時にかけるforce")]
    public float jumpForce;
    //足の当たり判定
    public DecisionRange dacision;

    // Update is called once per frame
    override protected void Update()
    {
        if (render == null)
        {
            return;
        }

        //画面内に表示されている場合
        if (render.isVisible)
        {
            //ジャンプ移動させる
            controller.ChangeStateJump();
            
        }
        //画面外にいる場合
        else
        {
            //動作を止める
            rigidBody.Sleep();
        }
    }

    //EnemyをJump移動させる
    public void JumpingEnemy()
    {
        //移動しながらJumpする
        //アニメーションの向きを左に設定する

        rigidBody.velocity = new Vector2(runSpeed, rigidBody.velocity.y);
        transform.localScale = new Vector3(scaleX, 1, 1);
        if (dacision.IsGround())
        {
            rigidBody.AddForce(transform.up * jumpForce);
        }
    }
}
