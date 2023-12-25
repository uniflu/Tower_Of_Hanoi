using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;

[CustomPropertyDrawer(typeof(MySceneAsset))]
public class MySceneAssetDrawer : PropertyDrawer
{
    bool hasProperty = false;
    SerializedProperty nameProperty;
    SerializedProperty sceneAssetProperty;

    private void Init(SerializedProperty property)
    {
        //データの取得
        if (!hasProperty)
        {
            nameProperty = property.FindPropertyRelative("_name");
            sceneAssetProperty = property.FindPropertyRelative("sceneAsset");
            hasProperty = true;
        }
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //初期化
        Init(property);

        //描画範囲を決定
        var fieldRect = position;
        fieldRect.height = EditorGUIUtility.singleLineHeight;

        // Prefab化した後プロパティに変更を加えた際に太字にしたりする機能を加えるためPropertyScopeを使う
        using (new EditorGUI.PropertyScope(fieldRect, label, property))
        {
            // ラベルを表示し、ラベルの右側のプロパティを描画すべき領域のpositionを得る
            fieldRect = EditorGUI.PrefixLabel(fieldRect, GUIUtility.GetControlID(FocusType.Passive), label);

            //シーンアセットの入力フィールドを表示
            var sceneRect = fieldRect;
            EditorGUI.PropertyField(sceneRect, sceneAssetProperty, GUIContent.none);

            //シーン名を取得
            nameProperty.stringValue = (sceneAssetProperty.objectReferenceValue as SceneAsset)?.name;
        }
    }

    //高さを取得
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        => EditorGUIUtility.singleLineHeight;
}
#endif

[Serializable]
public class MySceneAsset
{
#if UNITY_EDITOR
    [SerializeField] SceneAsset sceneAsset;
#endif

    [SerializeField] string _name;

    //文字列に黙示的に変換
    public static implicit operator string(MySceneAsset mySceneAsset)
    {
        return mySceneAsset._name;
    }
}