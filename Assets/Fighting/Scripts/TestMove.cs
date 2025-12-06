using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Rotate()
    {
        //Quaternion rot = Quaternion.LookRotation(target.transform.position);
        float speed = 2f;
        //Vector3 fixedRot = new Vector3(0,0,rot.z);
        //print(fixedRot);
        transform.LookAt(target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
       Rotate(); 
    }
}
