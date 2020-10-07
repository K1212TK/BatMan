using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleTrap : MonoBehaviour
{
    public GameObject trap;
    string playerTag = "Player";
    string enemyTag = "Enemy";
    string ThornTag = "Thorn";

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }

    //トラップに触れた際の処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (trap != null) {
            //プレイヤーがトラップに触れかつセットしている
            if (collision.tag == playerTag)
            {
                //gameObjectがEnemyであった場合
                if (trap.tag == enemyTag)
                {
                    //trap GameObjectをtrueに変更する
                    trap.SetActive(true);
                }
                //gameObjectがThornだった場合
                else if (trap.tag == ThornTag)
                {
                    //棘の落下処理実行
                    trap.GetComponent<FallTrap>().Fall();
                }
            }
        }
    }
}