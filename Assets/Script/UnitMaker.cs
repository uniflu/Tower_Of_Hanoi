using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMaker : MonoBehaviour
{
    [SerializeField] GameObject unitPrefab;
    [SerializeField] List<Color> unitColors;

    public static UnitMaker I { get; private set; }

    private void Awake()
    {
        I = this;
    }



    public void CreateUnits()
    {
        //GameDirector��Unit���X�g����ɂ���
        GameDirector.I.Units.Clear();

        //��̒i����`�����Ă���
        for (int i = 0; i < GlobalSetting.I.Step; i++)
        {
            //�z�u�ӏ�
            Vector3 pos = GameSceneSetting.I.GetPos(PolePos.LEFT, GlobalSetting.I.Step - i - 1);

            //�z�u
            GameObject obj = Instantiate(unitPrefab);
            obj.transform.position = pos;
            obj.name = $"unit_{i}";

            //�u���b�N�̑傫����ݒ肵�A�F��ύX
            Transform block = obj.transform.GetChild(0);//.GetComponent<TextMesh>();
            block.localScale = new Vector3(1.5f + 0.5f * i, 1, 1);

            //�F�ύX
            MeshRenderer meshRenderer = block.GetComponent<MeshRenderer>();
            meshRenderer.material.color = unitColors[i];


            //�e�L�X�g�̕�����ύX
            TextMesh textMesh = obj.transform.GetChild(1).GetComponent<TextMesh>();
            textMesh.text = $"{i + 1}";

            //GameDirector�̃��X�g�ɒǉ�����
            GameDirector.I.Units.Add(obj);
        }
    }
}
