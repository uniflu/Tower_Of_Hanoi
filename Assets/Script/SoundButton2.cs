using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//2つ以上の音を鳴らせるボタン
[Serializable]
public class SoundButton2
{
    [SerializeField] Button _button;
    [SerializeField] List<AudioClip> _audioClips;

    public Button Button => _button;

    private AudioClip _settingClip;


    //ボタンに処理を割り当てる
    public void Init()
    {
        //サウンドの割り当て
        _settingClip = _audioClips[0];

        //ボタンに処理を割り当てる
        _button.onClick.AddListener(() => AudioPlayer.I.PlaySE(_settingClip));
    }

    public void SetClip(int a)
    {
        _settingClip = _audioClips[a];
    }
}
