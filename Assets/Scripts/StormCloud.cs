using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormCloud : Enemy
{
    protected override void Start()
    {
        base.Start();

        rb.velocity = Vector2.right * speed;
    }
}
