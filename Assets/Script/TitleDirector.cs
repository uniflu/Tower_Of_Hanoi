using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class TitleDirector : MonoBehaviour
{
    [SerializeField] AudioClip titleBGM;
    [SerializeField] Dropdown stepDropdown;
    [SerializeField] SoundButton_C1 startButton;

    public static TitleDirector I { get; private set; }

    private void Awake()
    {
        I = this;
    }

    void Start()
    {
        //BGMを鳴らす
        AudioPlayer.I.PlayBGM(titleBGM);

        //ドロップダウンの選択肢編集
        stepDropdown.options?.Clear();//空にする
        for (int i = 3; i < 8; i++)
        {
            Dropdown.OptionData optionData = new Dropdown.OptionData($"{i}");
            stepDropdown.options.Add(optionData);
        }

        //ゲーム開始ボタンに処理を割り当ての割り当て
        Action startAction = () =>
        { 
            //ステップ数を更新
            GlobalSetting.I.Step = stepDropdown.value + 3;

            //シーンを読み込む
            SceneManager.LoadScene(SceneSetting.I.Main);

        };
        startButton.Init(()=>startAction());
    }

    //IEnumerator CorStartGame()
    //{
    //    //鳴り終わるまで待機
    //    yield return startButton.Cor();

       
        
    //}
}
