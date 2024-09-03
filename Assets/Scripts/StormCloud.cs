using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormCloud : MonoBehaviour
{
        //Variables//
    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private int health = 1;

    [SerializeField]
    private int goldFromDeath = 2;

    private Rigidbody2D rb;

      void Start()
    {
        //Makes the cloud move right//
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;
    }
            //Collision check//
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Bullet")
        {
            //remove health on collision//
            health--;
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                //give coins on destroy//
                ScoreManager.Instance.AddGold(goldFromDeath);
                Destroy(gameObject);
            }
        }
        // make enemys phase through each other//
        Physics2D.IgnoreLayerCollision(6, 6);
    }

}
