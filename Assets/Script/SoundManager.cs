using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //攻撃SE
    public AudioClip attackClip;
    //DownSE
    public AudioClip DownClip;
    //AudioSourceの情報をインスペクターから取得
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //攻撃SEの再生
    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(attackClip);
    }

    //ダウンSEの再生
    public void PlayDownSound()
    {
        audioSource.PlayOneShot(DownClip);
    }

}
