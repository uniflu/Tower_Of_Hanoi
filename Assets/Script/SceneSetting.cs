using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetting : MonoBehaviour
{
    [SerializeField] MySceneAsset title;
    [SerializeField] MySceneAsset main;


    public MySceneAsset Title => title;
    public MySceneAsset Main => main;

    public static SceneSetting I { get; private set; }

    private void Awake()
    {
        I = this;
    }
}
