using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkuAttack : MonoBehaviour
{
    private Character Iku;
    private GameObject Rin;

    // Start is called before the first frame update
    void Start()
    {
        Iku = GetComponent<Character>();
        Rin = GameObject.Find("Rintaro");

    }

    // Update is called once per frame
    void Update()
    {
        Iku.getMove(0).setTarget(Rin.transform.position);
        print(Iku.getMove(0).getTarget());
        Iku.canShootFunc(0);
        if(Iku.health > 35 && Iku.getMove(0).getShoot())
        {
//.getMove(0) finds the baseball attack used by iku
            GameObject bullet1 = Instantiate(Iku.getMove(0).gameObject, Iku.bulletSpawn.position, Quaternion.identity);
            bullet1.SetActive(true);
            bullet1.transform.SetParent(Iku.bulletTrash);
            Iku.getMove(0).setShoot(false);
        }
    }
}
