using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Variables
    [SerializeField]
    private float bulletSpeed = 10f;
    [SerializeField]
    private float maxLifeTime = 10f;
    private float currentLifeTime = 0f;
    Rigidbody2D rb;


    private void Awake()
    {
        //Makes bullet go up
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed;
    }

    private void Update()
    {
        //Despawns bullets after 10seconds as a fail safe for screen bounds
        currentLifeTime += Time.deltaTime;
        if (currentLifeTime >= maxLifeTime)
        {
            Destroy(gameObject);
        }
    }
}
