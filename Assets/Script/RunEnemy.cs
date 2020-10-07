using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEnemy : Enemy
{
    //走るEnemyのコントローラー
    public RunEnemyController controller;

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
            controller.ChangeStateRun();
        }
        //画面外にいる場合
        else
        {
            //動作を止める
            rigidBody.Sleep();
        }
        
    }

    //Enemyを歩かせる
    public void RunningEnemy()
    {
        //アニメーションの向きを左に変更する
        transform.localScale = new Vector3(scaleX, 1, 1);
        rigidBody.velocity = new Vector2(runSpeed, rigidBody.velocity.y);
    }
}
