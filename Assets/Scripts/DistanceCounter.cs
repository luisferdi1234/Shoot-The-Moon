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

    [Tooltip("How far the rocket needs to go before it wins!")]
    [SerializeField]
    private float maxDistance = 100f;
    [SerializeField]
    private GameObject WinScreenCanvas;
    [SerializeField] 
    private TextMeshProUGUI distanceText;

    //Fuel Variables
    [SerializeField]
    private Image fuelBar;
    [SerializeField]
    private float maxFuelAmount = 10f;

    private float fuelAmount = 10f;

    public float MaxFuelAmount { get => maxFuelAmount; set => maxFuelAmount = value; }
    public float FuelAmount { get => fuelAmount; set => fuelAmount = value; }

    void Update()
    {
        CheckDistance();
        //get time from the start of the fly phase
        timer += Time.deltaTime;

        //Updates kilometers every .1 seconds
        if (timer >= .1f)
        {
            timer = 0;
            AddDistance(.1f);
            DecreaseFuel(.1f);
            //Sets it to the second decimal place
            distance = (float)Mathf.Round(distance * 100f) / 100f;
        }

        //Updates on screen text
        distanceText.text = $"{distance.ToString()} Km";
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

            //Shows Win Screen
            WinScreenCanvas.SetActive(true);
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
            SceneManager.LoadScene("OutOfFuel");
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


}
