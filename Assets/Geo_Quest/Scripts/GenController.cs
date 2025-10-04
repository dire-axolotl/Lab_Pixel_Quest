using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenController : MonoBehaviour
{
    string var1 = "hello";
    float x  = .0001f;
    float y = 0f;
    float z = 0f;
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float speed = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (xInput*speed, rb.velocity.y);
        //float yInput = Input.GetAxis("Vertical");
        //rb.velocity = new Vector2(xInput, rb.velocity.y);
        Debug.Log(xInput);
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, 10);
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, -10);
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    rb.velocity = new Vector2(-10, rb.velocity.y);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    rb.velocity = new Vector2(10, rb.velocity.y);
        //}
    }
}
