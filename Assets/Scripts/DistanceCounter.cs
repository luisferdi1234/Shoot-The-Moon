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
    {
        timer += Time.deltaTime;
        
        if (timer > 5f) {
            CoinScore.coinsValue += 5;
            distance += 5;

            DistanceScore = distance.ToString();

            timer = 0;
        }
        
    }
}
