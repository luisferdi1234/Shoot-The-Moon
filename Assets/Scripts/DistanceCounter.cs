using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{
    //Distance Variables
    private float timer;
    private float distance = 0;
    [SerializeField] 
    private TextMeshProUGUI distanceText;

    //Fuel Variables
    [SerializeField]
    private Image fuelBar;
    [SerializeField]
    public float maxFuelAmount = 50f;
    private float fuelAmount = 50f;

    private void Start()
    {
        fuelAmount = maxFuelAmount;
    }

    void Update()
    { 
        //get time from the start of the fly phase
        timer += Time.deltaTime;

        //Updates kilometers every .1 seconds
        if (timer >= .1f)
        {
            timer = 0;
            distance += .1f;
            DecreaseFuel();
            //Sets it to the second decimal place
            distance = (float)Mathf.Round(distance * 100f) / 100f;
        }

        //Updates on screen text
        distanceText.text = $"{distance.ToString()} Km";
    }

    /// <summary>
    /// Lowers Fuel Bar on UI
    /// </summary>
    void DecreaseFuel()
    {
        fuelAmount -= .1f;
        fuelBar.fillAmount = fuelAmount / maxFuelAmount;
        CheckFuelAmount();
    }

    /// <summary>
    /// Increases Fuel Bar by a given amount
    /// </summary>
    /// <param name="pickupAmount"></param>
    void IncreaseFuel(float pickupAmount)
    {
        fuelAmount += pickupAmount;
        fuelAmount = Mathf.Clamp(fuelAmount, 0, maxFuelAmount);

        fuelBar.fillAmount = fuelAmount / maxFuelAmount;
    }

    /// <summary>
    /// Restarts the scene once player is out of fuel. We can make this do something else eventually.
    /// </summary>
    void CheckFuelAmount()
    {
        if (fuelAmount <= 0)
        {
            SceneManager.LoadScene("Scene0");
        }
    }
}
