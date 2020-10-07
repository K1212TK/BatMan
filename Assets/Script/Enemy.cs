using UnityEngine;

public class Enemy : MonoBehaviour
{
    //インスペクターから設定
    public SpriteRenderer render;
    public Rigidbody2D rigidBody;
    [Header("走るスピード")]
    public float runSpeed;
    [Header("break時にかかるforce")]
    public float breakForce;
    //自身のコライダー
    public CapsuleCollider2D enemyCollider;
    //defaultのScale
    protected float scaleX = -1;
   

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    virtual protected void Update()
    {
    }

    //パーツをバラバラにする
    public void BreakEnemy()
    {
        foreach (Transform part in GetComponentInChildren<Transform>().GetChild(0))
        {   
            //各パーツをアクティブに変更する
            part.gameObject.SetActive(true);
            //RigidBodyを取り付ける
            Rigidbody2D rigid = part.gameObject.AddComponent<Rigidbody2D>();
            //全てのパーツにrigidBodyを取り付け全てのパーツを分散させる
            rigid.AddForce(new Vector2(Random.Range(1000,breakForce+20), Random.Range(1000, breakForce + 20)));
            //各パーツの重さを10に設定
            rigid.mass = 10;
        }
        //アニメーションの破棄
        GameObject.Destroy(GetComponentInChildren<Transform>().GetChild(1).gameObject);
        //コライダーを消す
        enemyCollider.enabled = false;
    }

    //ブロックに衝突したら引き返すように設定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Blockと衝突した場合
        if (collision.collider.tag == "Block")
        {
          
            //Scaleを反転
            scaleX = scaleX * -1;
            //Runの方向を反転
            runSpeed = runSpeed * -1;
            
        }
    }
}


