using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public string scoreValueText;
    public float scoreValue = 0.0f;
    public float pointIncreasedPerSecond;

    void FixedUpdate()
    {
        scoreValueText = ((int)scoreValue).ToString();
        scoreValue = pointIncreasedPerSecond * Time.fixedDeltaTime;
    }

}
