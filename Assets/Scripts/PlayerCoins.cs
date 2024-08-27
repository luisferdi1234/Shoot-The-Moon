using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

public class PlayerCoins : MonoBehaviour
{

    private int gold = 0;
    [SerializeField] TMP_Text goldText;

    
    void Start()
    {
        //ScoreManager.Instance.SaveGold();
        gold = PlayerPrefs.GetInt("Gold");
        goldText.text = $"Gold: ${gold}";

    }



}
