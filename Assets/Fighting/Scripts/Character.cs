using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Move[] _moveList;
    public GameObject _characterSprite;
    // Start is called before the first frame update

    public float playerSpeed;
    private float _xVelocity = 0f;
    private float _yVelocity = 0f;
    private Rigidbody2D _rigidbody;

    public Transform bulletTrash;
    public Transform bulletSpawn;
    private bool canShoot = true;
    private float _currentTime;
    public String shotBy;


    public Character(Move[] moves, GameObject sprite)
    {
        this._moveList = moves; 
        this._characterSprite = sprite;
    }
    public Move getMove(int i)
    {
        return this._moveList[i];
    }



    private void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        
    }

    public void shootFunc(int i, KeyCode k)
    {
        //print(getMove(i).getShoot() + " false");
        if (Input.GetKeyDown(k) && getMove(i).getShoot())
        {
            //print("ran");
            GameObject bullet1 = Instantiate(getMove(i).gameObject, bulletSpawn.position, Quaternion.identity);
            bullet1.SetActive(true);
            bullet1.transform.SetParent(bulletTrash);
            getMove(i).setShoot(false);
        }
    }

    public void canShootFunc(int i)
    {
        if (!getMove(i).getShoot())
        {
            getMove(i).setTime(true);

            if (getMove(i).getTime() < 0)
            {
                getMove(i).setShoot(true);
                getMove(i).setTime(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if (collision.tag == shotBy)
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }

    public void charachterMove()
    {
        _xVelocity = Input.GetAxis(HW3Structs.Input.horizontal);
        _yVelocity = Input.GetAxis(HW3Structs.Input.vertical);
        _rigidbody.velocity = new Vector2(_xVelocity, _yVelocity) * playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        //print(getMove(0).getShoot());
        for (int i = 0; i < _moveList.Length; i++) {
            canShootFunc(i);
            shootFunc(i, getMove(i)._key);
            //print("hi");
         }
        charachterMove();
        //if(Input.GetKeyDown(kryvofr));
    }
}
