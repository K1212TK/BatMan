using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionRange : MonoBehaviour
{
    //地面のタグ名
    private string groundTag = "Ground";
    //敵パーツのタグ名
    private string partsTag = "Parts";
    //落下する地面のタグ名
    private string fallGroundTag = "FallGround";
    //ブロックのタグ名
    private string blockTag = "Block";

    //地面接地フラグ
    private bool isGround;
    //敵パーツ接地フラグ
    private bool isParts;
    //落下地面接地フラグ
    private bool isFallGround;
    //ブロック接地フラグ
    private bool isBlock;

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
        //地面に触れた(着地)の場合 
        if (collision.tag == groundTag)
        {
            isGround = true;
        }
        //敵のパーツに触れた場合
        if (collision.tag == partsTag)
        {
            isParts = true;
        }
        //落下する地面に触れた場合
        if (collision.tag == fallGroundTag)
        {
            isFallGround = true;

        }
        //ブロックに触れた場合
        if (collision.tag == blockTag)
        {
            isBlock = true;
        }
    }
    //判定に入り続けている場合
    private void OnTriggerStay2D(Collider2D collision)
    {
        //地面に触れ続けている場合　
        if (collision.tag == groundTag)
        {
            isGround = true;
        }
        //敵のパーツに触れ続けている場合
        if (collision.tag == partsTag)
        {
            isParts = true;
        }
        //ブロックに触れた場合
        if (collision.tag == blockTag)
        {
            isBlock = true;
        }
        //落下する地面に触れた場合
        if (collision.tag == fallGroundTag)
        {
            isFallGround = true;

        }
    }
    //判定範囲を出た場合　
    private void OnTriggerExit2D(Collider2D collision)
    {
        //地面から離れた場合 　
        if (collision.tag == groundTag)
        {
            isGround = false;
        }
        //敵パーツから離れた場合
        if (collision.tag == partsTag)
        {
            isParts = false;
        }
        //ブロックから離れた場合
        if (collision.tag == blockTag)
        {
            isBlock = false;
        }
        //落下する地面から離れた場合
        if (collision.tag == fallGroundTag)
        {
            isFallGround = false;

        }
    }

    //現在地面に足が触れているか否かのチェック
    public bool IsGround()
    {
        return isGround;
    }
    //現在敵パーツに足が触れているか否かのチェック
    public bool IsParts()
    {
        return isParts;
    }
    //現在落下地面に足が触れているか否かのチェック
    public bool IsFallGround()
    {
        return isFallGround;
    }
    //現在ブロックに足が触れているか否かのチェック
    public bool IsBlock()
    {
        return isBlock;
    }
}
