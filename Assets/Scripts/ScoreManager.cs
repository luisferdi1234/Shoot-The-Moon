using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;
using System;

public class ScoreManager : MonoBehaviour
{
    //Singleton pattern to make scoremanager accessible from anywhere
    public static ScoreManager Instance {  get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    //Variables
    private float goldTimer = 0;
    private bool timeIsRunning = true;
    private int gold = 0;

    [SerializeField]
    private TextMeshProUGUI goldText;
    [SerializeField]
    private int goldPerSecond = 1;

    // Start is called before the first frame update
    void Start()
    {
        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if time is running
        if(timeIsRunning)
        {
            goldTimer += Time.deltaTime;

            //If a second has passed, add gold to player
            if (goldTimer >= 1f)
            {
                goldTimer = 0f;
                AddGold(goldPerSecond);
            }
        }
    }

    /// <summary>
    /// Adds a given amount to the total gold the player has
    /// </summary>
    /// <param name="amount"></param>
    public void AddGold(int amount)
    {
        gold += amount;
        DisplayScore();
    }

    /// <summary>
    /// Updates the text UI to display the updated gold the player has
    /// </summary>
    /// <param name="timeToDisplay"></param>
    void DisplayScore ()
    {
        goldText.text = $"Gold: ${gold}";
    }
}
