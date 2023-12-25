using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioPlayer : MonoBehaviour
{
    //BGM用のオーディオソース
    [SerializeField] protected AudioSource bgmAudioSource;

    //SE用のオーディオソース
    List<AudioSource> seAudioSources = new List<AudioSource>();

    //シングルトンにすることでアクセスを容易にしている
    public static AudioPlayer I { get; private set; }


    private void Awake()
    {
        I = this;
    }

    //BGMを最初から鳴らす
    public void PlayBGM(AudioClip clip)
    {
        bgmAudioSource.clip = clip;
        bgmAudioSource.Play();
    }

    //BGMを一時停止
    public void PauseBGM()
    {
        bgmAudioSource.Pause();
    }

    //BGMを再開する
    public void UnPauseBGM()
    {
        bgmAudioSource.UnPause();
    }


    //BGMを停止
    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }

    //SEを鳴らす
    public AudioSource PlaySE(AudioClip clip)
    {
        //鳴らしていないAudioを順に探す
        var a = seAudioSources.FirstOrDefault(s => !s.isPlaying);

        //無かったら新しく追加する
        if (a == null)
        {
            //新たなゲームオブジェクトを作成して、子オブジェクトとして追加する
            GameObject obj = new GameObject("");
            obj.transform.SetParent(transform);


            //生成したobjにAudioSourceを追加して、リストに追加
            a = obj.AddComponent<AudioSource>();
            seAudioSources.Add(a);
        }

        //clipを設定
        a.clip = clip;

        //鳴らす
        a.Play();

        return a;
    }

    //すべてのSEを一時停止
    public void PauseAllSE()
    {
        foreach (var s in seAudioSources)
        {
            s.Pause();
        }
    }

    //すべてのSEを再開する
    public void UnPauseAllSE()
    {
        foreach (var s in seAudioSources)
        {
            s.UnPause();
        }
    }
}
