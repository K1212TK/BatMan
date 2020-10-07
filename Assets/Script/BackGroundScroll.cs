using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    //背景をスクロールさせるスピード
    public  float scrollSpeed;
    //背景のスクロールが終了する位置
    public  float deadLine;

    float startX;
    float startY;
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //背景をスクロールさせる
        Scroll();

    }

    public void Scroll()
    {
        //x座標をscrollSpeed分動かす
        this.transform.Translate(scrollSpeed, 0f, 0f);
            
        //背景のx座標がdeadLineと重なったら
        if (this.transform.position.x < deadLine) 
        {
            //背景をstartLineまで戻す
            this.transform.position = new Vector3(startX, startY, 0f);

        }
    }
}
