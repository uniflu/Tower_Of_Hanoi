using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MenuButtonsController : MonoBehaviour
{
    [SerializeField] SoundButton_C1 retryButton;
    [SerializeField] SoundButton_C1 titleButton;

    ////「Retry」を押す
    //IEnumerator OnClickRetryButton()
    //{
    //    //音が鳴り終わるまで
    //    yield return retryButton.Cor();

       
    //}

    ////「Back」を押す(タイトルに戻る)
    //IEnumerator OnClickTitleButton()
    //{
    //    //音が鳴り終わるまで
    //    yield return titleButton.Cor();

        
    //}

    //private void abc(int a)
    //{
        
    //}

    private void Start()
    {
        //Action a = () => abc(5);

        //「retry」
        Action retryAction = () =>
        {
            // 現在のSceneを取得
            Scene loadScene = SceneManager.GetActiveScene();

            // 現在のシーンを再読み込みする
            SceneManager.LoadScene(loadScene.name);
        };
        retryButton.Init(() => retryAction());

        //「Title」
        titleButton.Init(() => SceneManager.LoadScene(SceneSetting.I.Title));
    }
}
