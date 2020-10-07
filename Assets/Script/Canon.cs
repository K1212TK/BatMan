using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{

    //インスペクターから設定
    public GameObject bulletPrefab;
    public GameObject canon;
    public SpriteRenderer render;
    [Header("弾丸を生成する際の待ち時間")]
    public float waitTime;
    float timeleft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //画面内に表示されている場合
        if (render.isVisible)
        {
            //waitTimeおきに弾丸を生成する
            timeleft -= Time.deltaTime;
            if (timeleft <= 0.0)
            {
                timeleft = waitTime;
                //prefabの生成
                CreateBulletPrefab();
            }
        }
    }

    //弾丸のプレハブを作成
    void CreateBulletPrefab()
    {
        //prefabの生成
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y+0.2f, transform.position.z), transform.rotation);
        //Canonの子Objectへ配置
        bullet.transform.parent = canon.transform;
    }
}
