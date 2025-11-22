using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestChar : Character
{
    // Start is called before the first frame update
    public TestChar(Move[] moves, GameObject sprite) : base(moves,sprite){

    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        print(_moveList[0]);
        _moveList[0].useMove(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
