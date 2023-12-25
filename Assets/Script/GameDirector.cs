using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class UpDownButtons : SoundButton2
{
    //public Button button;
    public Text text;
}



public enum PolePos : int
{
    LEFT = 0,
    MIDDLE = 1,
    RIGHT = 2,
    NONE = 3
}


public class GameDirector : MonoBehaviour
{
    [SerializeField] AudioClip gameBGM;
    [SerializeField] AudioClip successSE;

    //どこのポールを選択しているか
    PolePos selectPolePos = PolePos.NONE;// = global::PoleNum.NONE;

    //どのUnitを選択しているか
    int selectUnitNum;

    const int PoleNum = 3;

    //ユニットリスト
    public List<GameObject> Units { get; set; } = new List<GameObject>();

    public static GameDirector I { get; private set; }

    //スタック
    public Stack<int>[] stacks;
    public UpDownButtons[] upDownButtons;
    [SerializeField] GameObject finishTextObj;

    private void Awake()
    {
        I = this;
    }

    private void Start()
    {
        //音楽を鳴らし始める
        AudioPlayer.I.PlayBGM(gameBGM);

        //ユニットを作成
        UnitMaker.I.CreateUnits();

        //初期設定
        selectPolePos = PolePos.NONE;

        //stackを初期化
        stacks = new Stack<int>[PoleNum];
        for (int i = 0; i < stacks.Length; i++)
        {
            stacks[i] = new Stack<int>();//.Clear();
        }

        //stackの0番目を設定
        for (int i = 0; i < GlobalSetting.I.Step; i++)
        {
            stacks[0].Push(GlobalSetting.I.Step - i - 1);
        }

        //UpDownボタンに処理を割り当て
        for (int i = 0; i < 3; i++)
        {
            upDownButtons[i].Init();
        }

        upDownButtons[0].Button.onClick.AddListener(() => OnClickUpDownButton(0));
        upDownButtons[1].Button.onClick.AddListener(() => OnClickUpDownButton(1));
        upDownButtons[2].Button.onClick.AddListener(() => OnClickUpDownButton(2));

        //オン・オフ
        upDownButtons[0].Button.gameObject.SetActive(true);
        upDownButtons[1].Button.gameObject.SetActive(false);
        upDownButtons[2].Button.gameObject.SetActive(false);
    }

    //UpDownボタンを押したときの処理
    void OnClickUpDownButton(int pos)
    {
        //選択していないときに上げる
        if (selectPolePos == PolePos.NONE) 
        {
            //選択しているポールを格納
            selectPolePos = (PolePos)Enum.ToObject(typeof(PolePos), pos);

            //選択しているユニットを格納
            selectUnitNum = stacks[(int)selectPolePos].Pop();

            //上にあげる
            Units[selectUnitNum].transform.position = GameSceneSetting.I.GetSelectPos(selectPolePos);

            //テキスト設定
            for (int i = 0; i < (int)PolePos.NONE; i++)
            {
                //現在選択している番号より大きい、or 空の時
                if (stacks[i].Count == 0 || stacks[i].Peek() > selectUnitNum)
                {
                    upDownButtons[i].Button.gameObject.SetActive(true);
                    upDownButtons[i].text.text = "Down";
                    upDownButtons[i].SetClip(1);
                }
                else
                {
                    upDownButtons[i].Button.gameObject.SetActive(false);
                }
            }
        }

        //降ろす
        else
        {
            //指定した位置に降ろす
            PolePos pos1 = (PolePos)Enum.ToObject(typeof(PolePos), pos);
            Units[selectUnitNum].transform.position = GameSceneSetting.I.GetPos(pos1, stacks[pos].Count);

            //下した位置 = 上げる位置以外なら回数を加算
            if (pos1 != selectPolePos)
            {
                MovesText.I.AddMoves();
            } 

            //スタックに追加
            stacks[pos].Push(selectUnitNum);

            //完成したかどうか判断(右のUnit数 = 段数)
            if (stacks[(int)PolePos.RIGHT].Count == GlobalSetting.I.Step)
            {
                Finish();
                return;
            }

            //上げる設定
            for (int i = 0; i < (int)PolePos.NONE; i++)
            {
                //ユニットが存在
                if (stacks[i].Count != 0)
                {
                    upDownButtons[i].Button.gameObject.SetActive(true);
                    upDownButtons[i].text.text = "Up";
                    upDownButtons[i].SetClip(0);
                }
                else
                {
                    upDownButtons[i].Button.gameObject.SetActive(false);
                }
            }

            //選択なし状態
            selectPolePos = PolePos.NONE;
        }
    }

    //終了時の処理
    void Finish()
    {
        //updownボタンを非表示にする
        foreach (var u in upDownButtons) 
        {
            u.Button.gameObject.SetActive(false);
        }

        //Finishテキストを表示
        finishTextObj.SetActive(true);

        //音楽を止める
        AudioPlayer.I.PauseBGM();//StopBGM();

        //効果音を鳴らす
        AudioPlayer.I.PlaySE(successSE);
    }
}
