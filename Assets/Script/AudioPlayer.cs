using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioPlayer : MonoBehaviour
{
    //BGM�p�̃I�[�f�B�I�\�[�X
    [SerializeField] protected AudioSource bgmAudioSource;

    //SE�p�̃I�[�f�B�I�\�[�X
    List<AudioSource> seAudioSources = new List<AudioSource>();

    //�V���O���g���ɂ��邱�ƂŃA�N�Z�X��e�Ղɂ��Ă���
    public static AudioPlayer I { get; private set; }


    private void Awake()
    {
        I = this;
    }

    //BGM���ŏ�����炷
    public void PlayBGM(AudioClip clip)
    {
        bgmAudioSource.clip = clip;
        bgmAudioSource.Play();
    }

    //BGM���ꎞ��~
    public void PauseBGM()
    {
        bgmAudioSource.Pause();
    }

    //BGM���ĊJ����
    public void UnPauseBGM()
    {
        bgmAudioSource.UnPause();
    }


    //BGM���~
    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }

    //SE��炷
    public AudioSource PlaySE(AudioClip clip)
    {
        //�炵�Ă��Ȃ�Audio�����ɒT��
        var a = seAudioSources.FirstOrDefault(s => !s.isPlaying);

        //����������V�����ǉ�����
        if (a == null)
        {
            //�V���ȃQ�[���I�u�W�F�N�g���쐬���āA�q�I�u�W�F�N�g�Ƃ��Ēǉ�����
            GameObject obj = new GameObject("");
            obj.transform.SetParent(transform);


            //��������obj��AudioSource��ǉ����āA���X�g�ɒǉ�
            a = obj.AddComponent<AudioSource>();
            seAudioSources.Add(a);
        }

        //clip��ݒ�
        a.clip = clip;

        //�炷
        a.Play();

        return a;
    }

    //���ׂĂ�SE���ꎞ��~
    public void PauseAllSE()
    {
        foreach (var s in seAudioSources)
        {
            s.Pause();
        }
    }

    //���ׂĂ�SE���ĊJ����
    public void UnPauseAllSE()
    {
        foreach (var s in seAudioSources)
        {
            s.UnPause();
        }
    }
}
