using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour

{ //set coin value 
    public static int coinsValue = 0;
    Text coins;

    void Start()
    {  //gets text from screen
        coins = GetComponent<Text> ();
    }

    
    void Update()
    { //updates coins statis on screen
        coins.text = "Coins" + coinsValue;
    }
}
