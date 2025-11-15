using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Object _character;
    private Move[] _moveList;
    private Sprite _characterSprite;
    // Start is called before the first frame update
    public Character(Object character, Move[] moves, Sprite sprite)
    {
        this._character = character;
        this._moveList = moves; 
        this._characterSprite = sprite;
    }
    public Move getMove(int i)
    {
        return this._moveList[i];
    }

    public void useMove(Vector2 targetLocation)
    {
         new Vector2(,)
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
