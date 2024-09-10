using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variables
    [SerializeField]
    protected float speed = 5.0f;

    [SerializeField]
    protected int health = 2;

    [SerializeField]
    protected int goldFromDeath = 1;

    protected Rigidbody2D rb;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        //Makes enemy move downwards
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks collision with bullets
        if (collision.gameObject.tag == "Bullet")
        {
            //Reduces enemy health
            health--;
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                //Awards coins on enemy death
                ScoreManager.Instance.AddGold(goldFromDeath);
                ScoreManager.Instance.IncreaseEnemyCount();
                Destroy(gameObject);
            }
        }
    }
}
