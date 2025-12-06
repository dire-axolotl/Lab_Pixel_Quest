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
        print(getMove(i).getShoot() + " false");
        if (Input.GetKeyDown(k) && getMove(i).getShoot())
        {
            print("ran");
            GameObject bullet1 = Instantiate(getMove(i).gameObject, bulletSpawn.position, Quaternion.identity);
            bullet1.SetActive(true);
            bullet1.transform.SetParent(bulletTrash);
            getMove(i).setShoot();
        }
    }


        // Update is called once per frame
        void Update()
    {
        for (int i = 0; i < _moveList.Length; i++) {
            shootFunc(i, getMove(i)._key);
            print("hi");
         }
        //if(Input.GetKeyDown(kryvofr));
    }
}
