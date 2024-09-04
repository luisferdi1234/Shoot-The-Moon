using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickUp : PickUp
{
    [Tooltip("What percentage of your fuel the pickup restores (.1 - 1)")]
    [SerializeField]
    public float fuelGained = .1f;
}
