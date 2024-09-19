using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMovement : Enemy
{

    public float radius = 2f;
    private float angle = 0f;

    void Update()
    {
        angle += speed * Time.deltaTime; // Increment the angle based on time and speed
        float x = Mathf.Cos(angle) * radius; // Calculate the x position
        float y = Mathf.Sin(angle) * radius; // Calculate the y position
        transform.position = new Vector3(x, y, 0); // Update the UFO position
    }

}
