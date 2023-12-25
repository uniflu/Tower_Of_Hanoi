using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSetting : MonoBehaviour
{
    public int Step { get; set; }


    public static GlobalSetting I { get; private set; }

    private void Awake()
    {
        I = this;
    }
}
