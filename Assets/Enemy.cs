using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }

   
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    
    void Update()
    {
        if(transform.position.y < screenBounds.y - 30){
            Destroy(this.gameObject);
        }
        
    }
}
