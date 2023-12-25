using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneSetting : MonoBehaviour
{
    [SerializeField] float poleInterval;//�|�[���Ԃ̕�
    [SerializeField] float bottomY;//��ԉ���y���W
    [SerializeField] float selectY;//�I������y���W
    
    //i�͉����牽�Ԗڂ�������
    public Vector3 GetPos(PolePos polePos, int i)
    {
        return new Vector3(((int)polePos - 1) * poleInterval,
            bottomY + i, 0);
    }

    //i�͉����牽�Ԗڂ�������
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
