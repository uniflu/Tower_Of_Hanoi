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
        //�f�[�^�̎擾
        if (!hasProperty)
        {
            nameProperty = property.FindPropertyRelative("_name");
            sceneAssetProperty = property.FindPropertyRelative("sceneAsset");
            hasProperty = true;
        }
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //������
        Init(property);

        //�`��͈͂�����
        var fieldRect = position;
        fieldRect.height = EditorGUIUtility.singleLineHeight;

        // Prefab��������v���p�e�B�ɕύX���������ۂɑ����ɂ����肷��@�\�������邽��PropertyScope���g��
        using (new EditorGUI.PropertyScope(fieldRect, label, property))
        {
            // ���x����\�����A���x���̉E���̃v���p�e�B��`�悷�ׂ��̈��position�𓾂�
            fieldRect = EditorGUI.PrefixLabel(fieldRect, GUIUtility.GetControlID(FocusType.Passive), label);

            //�V�[���A�Z�b�g�̓��̓t�B�[���h��\��
            var sceneRect = fieldRect;
            EditorGUI.PropertyField(sceneRect, sceneAssetProperty, GUIContent.none);

            //�V�[�������擾
            nameProperty.stringValue = (sceneAssetProperty.objectReferenceValue as SceneAsset)?.name;
        }
    }

    //�������擾
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

    //������ɖَ��I�ɕϊ�
    public static implicit operator string(MySceneAsset mySceneAsset)
    {
        return mySceneAsset._name;
    }
}