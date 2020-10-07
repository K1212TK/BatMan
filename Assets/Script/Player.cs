

using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    //敵のタグ名
    private string enemyTag = "Enemy";
    //棘のタグ名
    private string thornTag = "Thorn";

    [Header("歩くスピード")]
    public float walkSpeed;
    [Header("ジャンプ力")]
    public float jumpForce;
    [Header("ジャンプ時移動速度")]
    public float jumpSpeed;
    [Header("ダウンにかけるForce")]
    public float downForce;
    //移動速度
    private float xSpeed;

    public DecisionRange dacision;
    public Rigidbody2D rigidBody;
    public PlayerController playerController;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    //プレイヤーの動作を止める
    public void StopMove()
    {
        this.xSpeed = 0.0f;
        rigidBody.velocity = new Vector2(xSpeed, rigidBody.velocity.y);
    }

    //キャラクター右移動
    public void MoveRight()
    {
        //右方向歩く時の移動
        transform.localScale = new Vector3(1, 1, 1);
        this.xSpeed = walkSpeed;
        rigidBody.velocity = new Vector2(xSpeed, rigidBody.velocity.y);
    }

    //キャラクター左移動
    public void MoveLeft()
    {
        transform.localScale = new Vector3(-1, 1, 1);
        this.xSpeed = -walkSpeed;
        rigidBody.velocity = new Vector2(xSpeed, rigidBody.velocity.y);
    }

    //ジャンプモーション
    public void MoveJump()
    {
        rigidBody.AddForce(transform.up * jumpForce);
    }

    //ダウンアニメーションの実行
    public void MoveDown()
    {
        rigidBody.AddForce(transform.position * downForce);
    }

    //プレイヤーが衝突した際の処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //敵と衝突した場合
        if (collision.collider.tag == enemyTag)
        {
            //敵を踏んだ場合
            if (transform.position.y > collision.gameObject.transform.position.y + 1.5f)
            {
                //敵をブレイク状態に変更する
                collision.gameObject.GetComponent<EnemyController>().ChangeStateBreak();
            }
            //敵上部以外に衝突した場合
            else
            {
                //playerをダウン状態のステータスに変更する
                playerController.ChangeStateDown();
            }
        }
        //棘と衝突した場合
        if (collision.collider.tag == thornTag)
        {
            //playerをダウン状態のステータスに変更する
            playerController.ChangeStateDown();
        }
    }
}
