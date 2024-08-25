using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{
    //Variables
    private float timer;
    private float distance = 0;
    [SerializeField] TextMeshProUGUI distanceText;

    
    void Update()
    { 
        //get time from the start of the fly phase
        timer += Time.deltaTime;

        //Updates kilometers every .1 seconds
        if (timer >= .1f)
        {
            timer = 0;
            distance += .1f;
            //Sets it to the second decimal place
            distance = (float)Mathf.Round(distance * 100f) / 100f;
        }

        //Updates on screen text
        distanceText.text = $"{distance.ToString()} Km";
    }
}
