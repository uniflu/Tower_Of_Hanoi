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
        //BGM��炷
        AudioPlayer.I.PlayBGM(titleBGM);

        //�h���b�v�_�E���̑I�����ҏW
        stepDropdown.options?.Clear();//��ɂ���
        for (int i = 3; i < 8; i++)
        {
            Dropdown.OptionData optionData = new Dropdown.OptionData($"{i}");
            stepDropdown.options.Add(optionData);
        }

        //�Q�[���J�n�{�^���ɏ��������蓖�Ă̊��蓖��
        Action startAction = () =>
        { 
            //�X�e�b�v�����X�V
            GlobalSetting.I.Step = stepDropdown.value + 3;

            //�V�[����ǂݍ���
            SceneManager.LoadScene(SceneSetting.I.Main);

        };
        startButton.Init(()=>startAction());
    }
}
