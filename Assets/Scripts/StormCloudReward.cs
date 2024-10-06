using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StormCloudReward : Enemy
{
    [SerializeField]
    private GameObject goldPickUp;

    [SerializeField]
    private GameObject fuelPickUp;

    protected override void Start()
    {
        base.Start();

        if (transform.position.x < 0)
        {
            rb.velocity = Vector2.right * speed;
        }
        else
        {
            rb.velocity = Vector2.left * speed;
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
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

                SpawnPickUp();
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// Randomly chooses between both pickups and spawns one in
    /// </summary>
    void SpawnPickUp()
    {
        int selection = Random.Range(0, 2);
        if (selection == 0)
        {
            Instantiate(goldPickUp, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(fuelPickUp, transform.position, transform.rotation);
        }
    }
}


