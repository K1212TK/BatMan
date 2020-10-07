using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    string playerTag = "Player";

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }

    //衝突したら
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ゴールにプレイヤーが触れたら
        if (collision.collider.tag == playerTag)
        {
            //クリアパネルを展開する
            GManager.instance.OpenGameClearPanel();
        }
    }
}