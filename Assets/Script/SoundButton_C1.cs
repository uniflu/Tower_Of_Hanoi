using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class SoundButton_C1
{
    bool isInited = false; //���������ꂽ��
    [SerializeField] AudioClip _audioClip; //����
    [SerializeField] Button _button; //�{�^��

    //������(AudioSource�ɉ�����ݒ�)
    public void Init(Action action)
    {
        //�����������̃t���O
        isInited = true;

        //OnClick�ɉ���炷���������蓖�Ă�
        _button.onClick.AddListener(() => AudioPlayer.I.StartCoroutine(Play(action)));
    }

    //��I��������Ƃ�ʒm����R���[�`��(��I�������Aaction���N����)
    IEnumerator Play(Action action)
    {
        //����������Ă��Ȃ�������G���[
        if (!isInited)
        {
            Debug.LogError("AudioSource�ɉ�����ݒ肵�Ă��Ȃ�");
            yield break;
        }

        //�{�^�������͂��󂯕t���Ȃ��悤�ɂ���
        _button.enabled = false;

        //���ʉ���炷
        var a = AudioPlayer.I.PlaySE(_audioClip);

        //�I���܂őҋ@
        yield return new WaitWhile(() => a.isPlaying);

        //����
        action();

        //�{�^�������͂��󂯕t����悤�ɂ���
        _button.enabled = true;
    }
}
