using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charachter : MonoBehaviour
{
    private Move[] _moveList;
    private Sprite _charachterSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Move getMove(int i)
    {
        return this._moveList[i];
    }

    public void useMove()
    {

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
