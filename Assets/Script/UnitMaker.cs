using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMaker : MonoBehaviour
{
    [SerializeField] GameObject unitPrefab;
    //[SerializeField] int Step;//段数
    [SerializeField] List<Color> unitColors;

    //[SerializeField] Vector3 originPos;
    public static UnitMaker I { get; private set; }

    private void Awake()
    {
        I = this;
    }



    public void CreateUnits()
    {
        //GameDirectorのUnitリストを空にする
        GameDirector.I.Units.Clear();

        //上の段から形成していく
        for (int i = 0; i < GlobalSetting.I.Step; i++)
        {
            //配置箇所
            Vector3 pos = GameSceneSetting.I.GetPos(PolePos.LEFT, GlobalSetting.I.Step - i - 1);
            //new Vector3(GameSceneSetting.I.GetX(PolePos.LEFT), GameSceneSetting.I.GetY(i), 0);
            //Vector3 pos = new Vector3(- GameSceneSetting.I.poleInterval, GameSceneSetting.I.bottomY, 0)
            //    /*　originPos*/ + Vector3.up * (GlobalSetting.I.Step - i - 1);

            //配置
            GameObject obj = Instantiate(unitPrefab);
            obj.transform.position = pos;
            obj.name = $"unit_{i}";

            //ブロックの大きさを設定し、色を変更
            Transform block = obj.transform.GetChild(0);//.GetComponent<TextMesh>();
            block.localScale = new Vector3(1.5f + 0.5f * i, 1, 1);

            //色変更
            MeshRenderer meshRenderer = block.GetComponent<MeshRenderer>();
            meshRenderer.material.color = unitColors[i];


            //テキストの文字を変更
            TextMesh textMesh = obj.transform.GetChild(1).GetComponent<TextMesh>();
            textMesh.text = $"{i + 1}";

            //GameDirectorのリストに追加する
            GameDirector.I.Units.Add(obj);
        }

        //リストを返す
    }
}
