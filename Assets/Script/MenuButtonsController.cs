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

    private void Start()
    {
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
