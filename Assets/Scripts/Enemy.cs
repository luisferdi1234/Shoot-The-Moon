using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variables
    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private int health = 2;

    [SerializeField]
    private int goldFromDeath = 1;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        //Makes enemy move downwards
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks collision with bullets
        if (collision.gameObject.tag == "Bullet")
        {  // increase coin score on kill
            CoinScore.coinsValue += 10;
            //
            health--;
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                ScoreManager.Instance.AddGold(goldFromDeath);
                Destroy(gameObject);
            }
        }
    }
}
