using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewManager : MonoBehaviour
{
    //インスペクターから設定
    public RectTransform rectTrans;
    public GameObject arrow;
    //反転させるPos
    float inversionPos;
    // Start is called before the first frame update
    void Start()
    {
        //一番右端のPos
        inversionPos = -rectTrans.offsetMax.x;

    }

    // Update is called once per frame
    void Update()
    {

        float leftPos = rectTrans.offsetMin.x;
        float rightPos = -rectTrans.offsetMax.x;
        //一番左端までスクロールしたら矢印を反転させる
        if (leftPos <= inversionPos)
        {
            //矢印を左方向へ反転させる
            arrow.transform.localScale = new Vector3(-1, 1, 1);
        }
        //一番右端までスクロールしたら矢印を反転させる
        if (rightPos <= inversionPos)
        {
            //矢印を左方向へ反転させる
            arrow.transform.localScale = new Vector3(1, 1, 1);
            
        }
    }
}
