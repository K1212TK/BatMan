using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    //インスペクターから設定
    public Rigidbody2D rigid;
    public SurfaceEffector2D surface;
    
    [Header("移動スピード")]
    public float moveSpeed ;
    [Header("移動範囲")]
    public float moveRange ;
    [Header("移動方向　0:右　1:左")]
    public int moveDirection;

    //初期ポジション
    private Vector2 defaultPos;
    //ポジションの保存用
    private Vector2 prevPos;

    // Start is called before the first frame update
    void Start()
    {
        //初期位置を設定
        defaultPos = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //移動処理の実行
        Move();
    }

    //移動処理
    private void Move()
    {

        prevPos = rigid.position;
        Vector2 pos;
        if (moveDirection == 0)
        {
            // X座標横移動
            pos = new Vector2(defaultPos.x + Mathf.PingPong(Time.time * moveSpeed, moveRange), defaultPos.y);
        }
        else
        {
            // X座標横移動
            pos = new Vector2(defaultPos.x - Mathf.PingPong(Time.time * moveSpeed, moveRange), defaultPos.y);
        }

        rigid.MovePosition(pos);
        // 速度を逆算する
        Vector2 velocity = (pos - prevPos) / Time.deltaTime;
        // X座標を Surfaceのスピードへ適用
        surface.speed = velocity.x;
    }
}
