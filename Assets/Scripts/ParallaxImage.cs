using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ParallaxImage : MonoBehaviour
{
    //Variables
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    [SerializeField]
    private float moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //Makes object move down
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * moveSpeed;

        ChangeXPosition();
    }

    void Update()
    {
        // Check if the cloud has moved off the bottom of the screen
        if (transform.position.y < -screenBounds.y - 2)
        {
            // Reset the cloud's position to the top of the screen
            transform.position = new Vector3(transform.position.x, screenBounds.y + 2, transform.position.z);
            ChangeXPosition();
        }
    }

    /// <summary>
    /// Makes the cloud have a random x position when it spawns/spawns again
    /// </summary>
    void ChangeXPosition()
    {
        float x = Random.Range(-screenBounds.x, screenBounds.x);

        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
