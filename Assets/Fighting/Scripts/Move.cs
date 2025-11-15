using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    private Object _hitbox;
    private Sprite _sprite;
    private float _cooldown;
    private float _manaCost;
    private float _moveSpeed;

    public Move(Object hitbox, Sprite sprite, float cooldown, float manaCost, float moveSpeed) {
        this._hitbox = hitbox;
        this._sprite = sprite;
        this._cooldown = cooldown;
        this._manaCost = manaCost;
        this._moveSpeed = moveSpeed;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
