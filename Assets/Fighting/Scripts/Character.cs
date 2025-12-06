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

    public Transform bulletTrash;
    public Transform bulletSpawn;
    private bool canShoot = true;
    private float _currentTime;


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

    public void fireShoot()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < 250; i++)
            {
                GameObject bullet1 = Instantiate(getMove(0).gameObject, bulletSpawn.position, Quaternion.identity);
                bullet1.SetActive(true);
                bullet1.transform.position += new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0);
                bullet1.GetComponent<Rigidbody2D>().velocity = bullet1.transform.forward * 3000;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        //print(getMove(0).getShoot());
        for (int i = 0; i < _moveList.Length; i++) {
            if (i == 1)
            {
                fireShoot();
            }
            else
            {

                fireShoot();
            }
            canShootFunc(i);
            //print("hi");
        }
        //if(Input.GetKeyDown(kryvofr));
    }
}
