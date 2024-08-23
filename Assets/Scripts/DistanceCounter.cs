using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{
    
    public string DistanceScore;
    private float timer;
    private int distance;

    
    void Update()
    { //get time from the start of the fly phase
        timer += Time.deltaTime;
        //converts time to score value
        if (timer > 5f) {
            CoinScore.coinsValue += 5;
            distance += 5;
        //converts int to str
            DistanceScore = distance.ToString();
         //sets start timer to 0
            timer = 0;
        }
        
    }
}
