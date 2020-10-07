using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallGround : FallTrap
{
    string playerTag = "Player";

    //落下するまでの待機時間
    public float fallWaitTime;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
    }

    //落下時に時間を置く
    public void FallTimeWait()
    {
        if (!isFall)
        {
            Invoke("Fall", fallWaitTime);
        }
    }

    //判定範囲に入った場合　
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーが着地した場合
        if (collision.tag == playerTag)
        {
            FallTimeWait();
        }
            
    }
}
