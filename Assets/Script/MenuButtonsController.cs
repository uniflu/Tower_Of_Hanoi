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

    ////�uRetry�v������
    //IEnumerator OnClickRetryButton()
    //{
    //    //������I���܂�
    //    yield return retryButton.Cor();

       
    //}

    ////�uBack�v������(�^�C�g���ɖ߂�)
    //IEnumerator OnClickTitleButton()
    //{
    //    //������I���܂�
    //    yield return titleButton.Cor();

        
    //}

    //private void abc(int a)
    //{
        
    //}

    private void Start()
    {
        //Action a = () => abc(5);

        //�uretry�v
        Action retryAction = () =>
        {
            // ���݂�Scene���擾
            Scene loadScene = SceneManager.GetActiveScene();

            // ���݂̃V�[�����ēǂݍ��݂���
            SceneManager.LoadScene(loadScene.name);
        };
        retryButton.Init(() => retryAction());

        //�uTitle�v
        titleButton.Init(() => SceneManager.LoadScene(SceneSetting.I.Title));
    }
}
