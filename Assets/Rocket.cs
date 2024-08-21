using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    //Sets the health of the rocket, we should be setting this number later on using the health the player gets from the shop
    [SerializeField]
    private int health = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks collision with enemies and lowers health
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            health--;
            Debug.Log(health);
        }
    }
}
