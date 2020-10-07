using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    [Header("ゲームオーバー時のパネル")]
    public GameObject gameOverPanel;
    [Header("ゲームクリア時のパネル")]
    public GameObject gameClearPanel;
    [Header("ゲームポーズ時のパネル")]
    public GameObject gamePausePanel;
    [Header("Continue回数表示Text")]

    public Text continueNumText;
    public static GManager instance = null;
    //プレイ中かどうかの管理フラグ
    bool playFlg = true;
    //コンティニュー回数
    public static int continueNum = 0;
    //現在スコア
    private int score = 0;
    //残機
    private int life = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        //コンティニュー回数の表示
        ShowContinueNum();
        //ライフが0になったら
        if (life == 0 && playFlg)
        {
            //play中のフラグをfalseへ
            playFlg = false;
            //ゲームオーバーのパネルを展開する
            OpenGameOverPanel();
            //コンティニュー回数を+1する
            AddContinueNum();
        }
    }

    //スコアの追加
    public void AddScore(int addScore)
    {
        score = addScore;
    }

    //残機の減少
    public void RemoveLife()
    {
        life = life - 1;
    }

    //クリア時にパネルを展開する
    public void OpenGameClearPanel()
    {
        if (playFlg)
        {
            //ゲームクリアのパネルを展開する
            gameClearPanel.SetActive(true);
        }
    }

    //ゲームオーバーパネルを展開する
    public void OpenGameOverPanel()
    {
        //ゲームオーバーのパネルを展開する
        gameOverPanel.SetActive(true);
    }

    //ゲームをpauseする
    public void PauseGame()
    {
        Time.timeScale = 0f;
        //ゲームポーズパネルの展開
        gamePausePanel.SetActive(true);
    }

    //ゲームを再開する
    public void PlayGame()
    {
        Time.timeScale = 1f;
        //ゲームポーズパネルを閉じる
        gamePausePanel.SetActive(false);
    }

    //コンティニュー回数を増やす
    public void AddContinueNum()
    {
        continueNum++;
    }

    //コンティニュー回数を表示する
    public void ShowContinueNum()
    {
        continueNumText.text = continueNum.ToString();
    }

    public void ClearContinueNum()
    {

        continueNum = 0;
    }
}
