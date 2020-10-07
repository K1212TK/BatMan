using UnityEngine;

public class Attack : MonoBehaviour
{

    private string enemyTag = "Enemy";

    public PlayerController plController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    //敵オブジェクトが当たり判定内に侵入している間呼び出される
    void OnTriggerStay2D(Collider2D col)
    {
        //侵入してきたのがEnemyの場合
        if (col.tag == enemyTag)
        {
            //playerのステータスがattackの場合
            if (plController.GetStateName() == "attack")
            {
                //敵を破壊する
                col.GetComponent<Enemy>().BreakEnemy();
            }
        }
    }
}
