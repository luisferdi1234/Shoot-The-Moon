using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{ 
    public string scoreValueText;
    //sets start time to 0
    public float scoreValue = 0.0f;
    public float pointIncreasedPerSecond;

    void FixedUpdate()
    { //updates text on screen
        scoreValueText = ((int)scoreValue).ToString();
        //increase screen time per second
        scoreValue = pointIncreasedPerSecond * Time.fixedDeltaTime;
    }

}
