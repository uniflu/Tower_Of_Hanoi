using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//2�ȏ�̉���点��{�^��
[Serializable]
public class SoundButton2
{
    [SerializeField] Button _button;
    [SerializeField] List<AudioClip> _audioClips;

    public Button Button => _button;

    private AudioClip _settingClip;


    //�{�^���ɏ��������蓖�Ă�
    public void Init()
    {
        //�T�E���h�̊��蓖��
        _settingClip = _audioClips[0];

        //�{�^���ɏ��������蓖�Ă�
        _button.onClick.AddListener(() => AudioPlayer.I.PlaySE(_settingClip));
    }

    public void SetClip(int a)
    {
        _settingClip = _audioClips[a];
    }
}
