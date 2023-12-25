using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class SoundButton_C1
{
    bool isInited = false; //初期化されたか
    [SerializeField] AudioClip _audioClip; //音源
    [SerializeField] Button _button; //ボタン

    //初期化(AudioSourceに音源を設定)
    public void Init(Action action)
    {
        //初期化完了のフラグ
        isInited = true;

        //OnClickに音を鳴らす処理を割り当てる
        _button.onClick.AddListener(() => AudioPlayer.I.StartCoroutine(Play(action)));
    }

    //鳴り終わったことを通知するコルーチン(鳴り終わったら、actionを起こす)
    IEnumerator Play(Action action)
    {
        //初期化されていなかったらエラー
        if (!isInited)
        {
            Debug.LogError("AudioSourceに音源を設定していない");
            yield break;
        }

        //ボタンが入力を受け付けないようにする
        _button.enabled = false;

        //効果音を鳴らす
        var a = AudioPlayer.I.PlaySE(_audioClip);

        //終了まで待機
        yield return new WaitWhile(() => a.isPlaying);

        //処理
        action();

        //ボタンが入力を受け付けるようにする
        _button.enabled = true;
    }
}
