using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    //インスペクターから設定
    public Rigidbody2D rigidBody;

    [Header("弾のスピード　左方向へ飛ばす場合マイナス値")]
    public int bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //弾丸を動かす
        Shoot();
        //一定の距離まで移動したらDestroyする
        if (transform.position.x <= 20f)
        {
            Break();
        }
    }

    //弾丸を撃つ
    public void Shoot()
    {
        //弾の移動
        rigidBody.velocity = new Vector2(bulletSpeed, rigidBody.velocity.y);
    }

    //弾丸の消滅
    public void Break()
    {
        //弾をDestroy
        Destroy(gameObject);
    }

    //弾丸がplayerのコライダーに衝突した場合
    void OnCollisionEnter2D(Collision2D collision)
    {
        //衝突した対象がplayerであった場合
        //if (collision.gameObject.tag == "Player")
        //{
            //弾丸の消滅
            Break();
        //}
    }
}