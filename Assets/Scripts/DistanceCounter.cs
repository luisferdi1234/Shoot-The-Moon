using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{
    //Singleton pattern to make DistanceCounter accessible from anywhere
    public static DistanceCounter Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    //Distance Variables
    private float timer;
    private float distance = 0;
    private bool gameRunning = true;


    [Tooltip("How far the rocket needs to go before it wins!")]
    [SerializeField]
    private float maxDistance = 100f;
    [SerializeField]
    private GameObject WinScreenCanvas;
    [SerializeField]
    private TextMeshProUGUI winScreenText;
    [SerializeField] 
    private TextMeshProUGUI distanceText;

   // private int level = 1;

    //Fuel Variables
    [SerializeField]
    private Image fuelBar;
    [SerializeField]
    private float maxFuelAmount = 10f;
    public float distancevar;
    private float fuelAmount = 10f;
    public GameObject winscreen;

    public float MaxFuelAmount { get => maxFuelAmount; set => maxFuelAmount = value; }
    public float FuelAmount { get => fuelAmount; set => fuelAmount = value; }
    public bool GameRunning { get => gameRunning;}

    void Update()
    {
        CheckDistance();
        //get time from the start of the fly phase
        timer += Time.deltaTime;

        //Updates kilometers every .1 seconds
        if (timer >= .1f && gameRunning)
        {
            timer = 0;
            AddDistance(.1f);
            DecreaseFuel(.1f);
            //Sets it to the second decimal place
            distance = (float)Mathf.Round(distance * 100f) / 100f;
        }

        //Updates on screen text
        distanceText.text = $"{distance.ToString()} Km";
        
        //setts win condition to 50km and 10 enemy kills
        if (distance >= distancevar)
        {
            //Makes fuel counter stop ticking
            gameRunning = false;

            //Shows win Screen
            WinScreenCanvas.SetActive(true);
            SetWinScreenText();
            
            
            //save level progress
            //();
            // winscreen.SetActive(true);
            /////saveLevel();
            ScoreManager.Instance.SaveGold(); 
        }

    }

    void saveLevel()
    {
        int totalLevel = PlayerPrefs.GetInt("Level");
        ///////totalLevel += level;
        PlayerPrefs.SetInt("Level", totalLevel);
    }


    /// <summary>
    /// Checks how far the player has traveled and pops up the win screen
    /// </summary>
    void CheckDistance()
    {
        if (distance >= maxDistance)
        {
            //Saves current gold in case player wants to keep playing
            ScoreManager.Instance.SaveGold();

            //Makes fuel counter stop ticking
            gameRunning = false;
            //Shows Win Screen
            WinScreenCanvas.SetActive(true);
            SetWinScreenText();
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Lowers Fuel Bar on UI
    /// </summary>
    public void DecreaseFuel(float amount)
    {
        fuelAmount -= amount;
        fuelBar.fillAmount = fuelAmount / maxFuelAmount;
        CheckFuelAmount();
    }

    /// <summary>
    /// Increases Fuel Bar by a given amount
    /// </summary>
    /// <param name="pickupAmount"></param>
    public void IncreaseFuel(float pickupAmount)
    {
        fuelAmount += pickupAmount;
        fuelAmount = Mathf.Clamp(fuelAmount, 0, maxFuelAmount);

        fuelBar.fillAmount = fuelAmount / maxFuelAmount;
    }

    /// <summary>
    /// Goes to store page once the player runs out of fuel
    /// </summary>
    void CheckFuelAmount()
    {
        if (fuelAmount <= 0)
        {
            ScoreManager.Instance.SaveGold();

            //Makes fuel counter stop ticking
            gameRunning = false;

            
            //Shows loss Screen
            WinScreenCanvas.SetActive(true);
           
            SetLossScreenText();
        }
    }

    /// <summary>
    /// Gives a warning when fuel is below 20%
    /// </summary>
    void FuelWarning()
    {
        if(fuelAmount <= maxFuelAmount * .2f)
        {
          

        }
    }

    /// <summary>
    /// Adds a given distance to the distance counter.
    /// </summary>
    /// <param name="kilometers"></param>
    public void AddDistance(float kilometers)
    {
        distance += kilometers;
    }
 
    /// <summary>
    /// Sets the text on the win screen canvas
    /// </summary>
    void SetWinScreenText()
    {
        winscreen.SetActive(true);
        winScreenText.text = $"\nDistance: {distance} Km\n Enemies Defeated: {ScoreManager.Instance.EnemiesDefeated} \nCoins Earned: {ScoreManager.Instance.Gold}";
        
    }

    /// <summary>
    /// Sets the text on the loss screen canvas
    /// </summary>
    void SetLossScreenText()
    {
        winScreenText.text = $"You Lost.\nDistance: {distance} Km\n Enemies Defeated: {ScoreManager.Instance.EnemiesDefeated} \nCoins Earned: {ScoreManager.Instance.Gold}";
    }

}
