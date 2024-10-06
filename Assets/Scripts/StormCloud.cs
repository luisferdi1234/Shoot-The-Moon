using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class StormCloud : Enemy
{

   //Variables//
    public float distance = 10.0f;
    private bool movingRight = true;
    private Vector3 startPosition;



    void Update()
    { //change direction and flip enemy//
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (Vector3.Distance(startPosition, transform.position) >= distance)
        {
            movingRight = !movingRight;
            Flip();
        }
    }
    //flip stormCloud enemy//
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}



