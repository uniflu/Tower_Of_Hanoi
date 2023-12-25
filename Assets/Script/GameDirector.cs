using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class UpDownButtons : SoundButton2
{
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

    //�ǂ��̃|�[����I�����Ă��邩
    PolePos selectPolePos = PolePos.NONE;

    //�ǂ�Unit��I�����Ă��邩
    int selectUnitNum;

    const int PoleNum = 3;

    //���j�b�g���X�g
    public List<GameObject> Units { get; set; } = new List<GameObject>();

    public static GameDirector I { get; private set; }

    //�X�^�b�N
    public Stack<int>[] stacks;
    public UpDownButtons[] upDownButtons;
    [SerializeField] GameObject finishTextObj;

    private void Awake()
    {
        I = this;
    }

    private void Start()
    {
        //���y��炵�n�߂�
        AudioPlayer.I.PlayBGM(gameBGM);

        //���j�b�g���쐬
        UnitMaker.I.CreateUnits();

        //�����ݒ�
        selectPolePos = PolePos.NONE;

        //stack��������
        stacks = new Stack<int>[PoleNum];
        for (int i = 0; i < stacks.Length; i++)
        {
            stacks[i] = new Stack<int>();//.Clear();
        }

        //stack��0�Ԗڂ�ݒ�
        for (int i = 0; i < GlobalSetting.I.Step; i++)
        {
            stacks[0].Push(GlobalSetting.I.Step - i - 1);
        }

        //UpDown�{�^���ɏ��������蓖��
        for (int i = 0; i < 3; i++)
        {
            upDownButtons[i].Init();
        }

        upDownButtons[0].Button.onClick.AddListener(() => OnClickUpDownButton(0));
        upDownButtons[1].Button.onClick.AddListener(() => OnClickUpDownButton(1));
        upDownButtons[2].Button.onClick.AddListener(() => OnClickUpDownButton(2));

        //�I���E�I�t
        upDownButtons[0].Button.gameObject.SetActive(true);
        upDownButtons[1].Button.gameObject.SetActive(false);
        upDownButtons[2].Button.gameObject.SetActive(false);
    }

    //UpDown�{�^�����������Ƃ��̏���
    void OnClickUpDownButton(int pos)
    {
        //�I�����Ă��Ȃ��Ƃ��ɏグ��
        if (selectPolePos == PolePos.NONE) 
        {
            //�I�����Ă���|�[�����i�[
            selectPolePos = (PolePos)Enum.ToObject(typeof(PolePos), pos);

            //�I�����Ă��郆�j�b�g���i�[
            selectUnitNum = stacks[(int)selectPolePos].Pop();

            //��ɂ�����
            Units[selectUnitNum].transform.position = GameSceneSetting.I.GetSelectPos(selectPolePos);

            //�e�L�X�g�ݒ�
            for (int i = 0; i < (int)PolePos.NONE; i++)
            {
                //���ݑI�����Ă���ԍ����傫���Aor ��̎�
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

        //�~�낷
        else
        {
            //�w�肵���ʒu�ɍ~�낷
            PolePos pos1 = (PolePos)Enum.ToObject(typeof(PolePos), pos);
            Units[selectUnitNum].transform.position = GameSceneSetting.I.GetPos(pos1, stacks[pos].Count);

            //�������ʒu = �グ��ʒu�ȊO�Ȃ�񐔂����Z
            if (pos1 != selectPolePos)
            {
                MovesText.I.AddMoves();
            } 

            //�X�^�b�N�ɒǉ�
            stacks[pos].Push(selectUnitNum);

            //�����������ǂ������f(�E��Unit�� = �i��)
            if (stacks[(int)PolePos.RIGHT].Count == GlobalSetting.I.Step)
            {
                Finish();
                return;
            }

            //�グ��ݒ�
            for (int i = 0; i < (int)PolePos.NONE; i++)
            {
                //���j�b�g������
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

            //�I���Ȃ����
            selectPolePos = PolePos.NONE;
        }
    }

    //�I�����̏���
    void Finish()
    {
        //updown�{�^�����\���ɂ���
        foreach (var u in upDownButtons) 
        {
            u.Button.gameObject.SetActive(false);
        }

        //Finish�e�L�X�g��\��
        finishTextObj.SetActive(true);

        //���y���~�߂�
        AudioPlayer.I.PauseBGM();//StopBGM();

        //���ʉ���炷
        AudioPlayer.I.PlaySE(successSE);
    }
}
