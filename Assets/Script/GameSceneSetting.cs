using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneSetting : MonoBehaviour
{
    [SerializeField] float poleInterval;//ポール間の幅
    [SerializeField] float bottomY;//一番下のy座標
    [SerializeField] float selectY;//選択時のy座標

    //float GetX(PolePos polePos)
    //{
    //    return ((int)polePos - 1) * poleInterval;
    //}

    //float GetY(int i)
    //{
    //    return bottomY + GlobalSetting.I.Step - i - 1;
    //}
    
    //iは下から何番目かを示す
    public Vector3 GetPos(PolePos polePos, int i)
    {
        return new Vector3(((int)polePos - 1) * poleInterval,
            bottomY + i, 0);
    }

    //iは下から何番目かを示す
    public Vector3 GetSelectPos(PolePos polePos)
    {
        return new Vector3(((int)polePos - 1) * poleInterval,
            selectY, 0);
    }


    public static GameSceneSetting I { get; private set; }

    private void Awake()
    {
        I = this;
    }
}
