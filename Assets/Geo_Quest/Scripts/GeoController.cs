using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GenController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;

    public float speed = 5f;
    public string nextLevel = "Geo_Quest_Scene_2";
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //hitColider = GetComponent<Collider>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                {
                    string thisLevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thisLevel);

                    break;
                }
            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
        //Debug.Log(xInput);


    }
}
