using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour

{
    public static int coinsValue = 0;
    Text coins;

    void Start()
    {
        coins = GetComponent<Text> ();
    }

    
    void Update()
    {
        coins.text = "Coins" + coinsValue;
    }
}
