using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Move[] _moveList;
    public GameObject _characterSprite;
    // Start is called before the first frame update
    public Character(Move[] moves, GameObject sprite)
    {
        this._moveList = moves; 
        this._characterSprite = sprite;
    }
    public Move getMove(int i)
    {
        return this._moveList[i];
    }






    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(kryvofr));
    }
}
