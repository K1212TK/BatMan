using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrap : MonoBehaviour
{
    //落下済みかどうかの判定フラグ
    protected bool isFall = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //落下処理
    public virtual void Fall()
    {
        if (!isFall)
        {
            isFall = true;
            gameObject.AddComponent<Rigidbody2D>();
        }
    }
}
