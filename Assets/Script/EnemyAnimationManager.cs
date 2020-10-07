using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : AnimationManager
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        animations = new Dictionary<int, string>();

        animations.Add(1, "run");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
