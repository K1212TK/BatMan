using EnemyState;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    protected Dictionary<int, string> animations;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //現在流しているアニメーションを全てfalseに設定する
    public void SetFalseAllAnimation()
    {
        //dictionaryがnullでなければ
        if (animations != null) {
            foreach (KeyValuePair<int, string> animation in animations)
            {
                //animationが再生中であった場合
                if (animator.GetBool(animation.Value))
                {
                    animator.SetBool(animation.Value, false);
                }
            }
        }
    }

    //指定のanimationをtrueにする
    public void SetTrueAnimation(int animationKey)
    {

        if (!animator.GetBool(animations[animationKey]))
        {
            animator.SetBool(animations[animationKey], true);
        }
    }

    //指定のアニメーションをfalseにする
    public void SetFalseAnimation(int animationKey)
    {
        if (animator.GetBool(animations[animationKey]))
        {
            animator.SetBool(animations[animationKey], false);
        }
    }
}
