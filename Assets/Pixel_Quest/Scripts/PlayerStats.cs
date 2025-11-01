using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int health = 3;
    private int maxHealth = 3;
    
    public int coinCounter = 0;
    public string nextLevel = "";
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                {
                    health--;
                    
                    break;
                }
            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
            case "Coin":
                {
                    coinCounter++;
                    Destroy(collision.gameObject);
                    break;
                }
            case "Health":
                {
                    if(health < maxHealth - 1)
                    {
                        health++;
                        Destroy(collision.gameObject);
                    }
                    break;
                }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            string thisLevel = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(thisLevel);
        }
    }
}
