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

        Invoke("destory", 10f);
    }

    void destory()
    {
        Destroy(this);
    }
    
}
