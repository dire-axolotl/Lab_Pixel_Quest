using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkuAttack : MonoBehaviour
{
    private Character Iku;
    private GameObject Rin;
    private float timer;
    private float currentTime;
    private float currentDegree;
    private float targetDegree;
    private int polarity;
    private Vector3 bulletTarget;

    // Start is called before the first frame update
    void Start()
    {
        Iku = GetComponent<Character>();
        Rin = GameObject.Find("Rintaro");
        timer = 2;
        currentTime = timer;
        targetDegree = 180;
        currentDegree = targetDegree;
        polarity = 1;
    }

    void phaseOneTargeting()
    {

    }

    void bulletMaker(Vector3 target)
    {
        GameObject bullet1 = Instantiate(Iku.getMove(0).gameObject, Iku.bulletSpawn.position, Quaternion.identity);
        bullet1.GetComponent<Move>().setTarget(target);
        bullet1.SetActive(true);
        bullet1.transform.SetParent(Iku.bulletTrash);
        Iku.getMove(0).setShoot(false);
    }

   void timerFunc()
    {
        currentTime -= Time.deltaTime;
        currentDegree -= targetDegree / (2 / Time.deltaTime) * polarity;
        if (currentTime <= 0)
        {
            currentTime = this.timer;
            currentDegree = targetDegree * polarity;
            polarity *= -1;
        }
    }


    Vector3 vectorRot(Vector3 target)
    {
        return Quaternion.AngleAxis(currentDegree, Vector3.up) * target;
    }

    void Update()
    {
        timerFunc();

        Iku.getMove(0).setTarget(Rin.transform.position);
        //print(Iku.getMove(0).getTarget() + "Iku target");
        //print(Iku.getMove(0).getTarget());
        Iku.canShootFunc(0);
        if (Iku.health > 35 && Iku.getMove(0).getShoot())
        {
            //.getMove(0) finds the baseball attack used by iku
            bulletTarget = vectorRot(Rin.transform.position);
            bulletMaker(bulletTarget);
        }
        else
        {
            Iku.fireShoot(100);
        }
    }
}
