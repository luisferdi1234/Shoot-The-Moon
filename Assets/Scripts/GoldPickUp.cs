using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUp : PickUp
{
    [Tooltip("How much gold is gained from the pickup")]
    [SerializeField]
    public int goldGained = 10;
}
