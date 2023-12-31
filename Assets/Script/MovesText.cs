using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovesText : MonoBehaviour
{
    [SerializeField] Text text;
    int moves = 0;

    public static MovesText I { get; private set; }

    private void Awake()
    {
        I = this;
    }

    //動かした回数を加算
    public void AddMoves()
    {
        moves++;

        text.text = $"Moves : {moves}";
    }
}
