using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    //前回展開したシーン名
    static string beforeSceneName = "";
    //Stage1ゲームシーン名
    string stage1SceneName = "Stage1";
    //Stage2ゲームシーン名
    string stage2SceneName = "Stage2";
    //Stage3ゲームシーン名
    string stage3SceneName = "Stage3";
    //タイトルシーン名
    string titleSceneName = "StartScene";
    //ステージ選択シーン名
    string stageSelectSceneName = "StageSelectScene";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Stage1に遷移する
    public void ChangeStage1()
    {
        CheckBeforeAfterSceneName(stage1SceneName);
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage1SceneName);
        beforeSceneName = stage1SceneName;
    }

    //Stage2に遷移する
    public void ChangeStage2()
    {
        CheckBeforeAfterSceneName(stage2SceneName);
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage2SceneName);
        beforeSceneName = stage2SceneName;
    }

    //Stage3に遷移する
    public void ChangeStage3()
    {
        CheckBeforeAfterSceneName(stage3SceneName);
        UnityEngine.SceneManagement.SceneManager.LoadScene(stage3SceneName);
        beforeSceneName = stage3SceneName;
    }

    //タイトルシーンに遷移する
    public void ChangeTitleScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(titleSceneName);
    }

    //ステージ選択シーンに遷移する
    public void ChangeStageSelectScene()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(stageSelectSceneName);
    }

    //前回のシーン名と今回のシーン名が同じかの確認
    public void CheckBeforeAfterSceneName(string afterSceneName)
    {
        //前回シーン名と今回切り替えるシーン名が同じでなければ
        if (!beforeSceneName.Equals(afterSceneName))
        {
            //continueを0に戻す
            GManager.continueNum = 0;
        }
    }
}
