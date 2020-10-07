using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThorn : FallTrap
{

    //地面のタグ名
    private string groundTag = "Ground";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //判定範囲に入った場合　
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //地面に触れた場合
        if (collision.tag == groundTag)
        {
            Invoke("DestroyThorn", 0.3f);
        }
    }

    //棘のオブジェクトを消す
    public void DestroyThorn()
    {
        //棘を消す
        Destroy(this.gameObject);
    }
}
