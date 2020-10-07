using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : AnimationManager
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
    {
        animations = new Dictionary<int, string>();

        animations.Add(1, "run");
        animations.Add(2, "jump");
        animations.Add(3, "attack");
        animations.Add(4, "down");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
