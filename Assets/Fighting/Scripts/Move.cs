using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    public GameObject _move;
    public GameObject _hitbox;
    public GameObject _sprite;
    public float _cooldown;
    public float _manaCost;
    public float _moveSpeed;

    public Move(GameObject move,GameObject hitbox, GameObject sprite, float cooldown, float manaCost, float moveSpeed) {
        this._hitbox = hitbox;
        this._sprite = sprite;
        this._cooldown = cooldown;
        this._manaCost = manaCost;
        this._moveSpeed = moveSpeed;
    }

    public void useMove(Vector3 targetLocation)
    {
        _move.SetActive(true);

        Vector3 pos = targetLocation - transform.position;

        float rotZ = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ - 90);
        //Vector3.MoveTowards(this.transform.position, targetLocation,this._moveSpeed*Time.deltaTime);
        //Vector3 mouseDirection = Vector3.RotateTowards(this.transform.position,targetLocation,7f,7f);
        //print(mouseDirection);
        //transform.rotation = Quaternion.LookRotation(mouseDirection);
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
