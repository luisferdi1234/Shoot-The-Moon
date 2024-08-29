using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LaunchScript : MonoBehaviour
{
    //Variables
    [SerializeField]
    GameObject gameUI;

    [SerializeField]
    private GameObject rocket;

    [SerializeField]
    private Image launchBar;

    [SerializeField]
    private Image maxPower;

    [SerializeField]
    private float timeToFill = .8f;

    [SerializeField]
    private float minimumFuelPercentage = .5f;

    private int goldFromPerfectLaunch = 30;

    private float distanceFromPerfectLaunch = 10f;

    DistanceCounter distanceCounter;

    private float launchPower = 0;

    private bool increasing = true;

    //Input System Variables
    private PlayerControls playerControls;
    private InputAction fire;

    public int GoldFromPerfectLaunch { get => goldFromPerfectLaunch; set => goldFromPerfectLaunch = value; }
    public float DistanceFromPerfectLaunch { get => distanceFromPerfectLaunch; set => distanceFromPerfectLaunch = value; }

    private void Awake()
    {
        //Input System
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        //Input System
        fire = playerControls.Player.Fire;
        fire.performed += Fire;
        fire.Enable();
    }

    private void OnDisable()
    {
        //Input System
        fire.Disable();
    }

    private void Update()
    {
        //Increases and Decreases the launch bar
        if (increasing)
        {
            launchPower += Time.deltaTime / timeToFill;

            if (launchPower >= 1)
            {
                increasing = false;
            }
            UpdateBar();
        }
        else
        {
            launchPower -= Time.deltaTime / timeToFill;

            if (launchPower <= 0)
            {
                increasing = true;
            }
            UpdateBar();
        }
    }

    /// <summary>
    /// Creates a bullet after the fire button is pressed
    /// </summary>
    /// <param name="context"></param>
    private void Fire(InputAction.CallbackContext context)
    {
        CheckPowerBar();

        //Allows player to move rocket now
        rocket.GetComponent<Rocket>().enabled = true;

        //Turns off Launch UI
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Checks how much power the fuel bar has and sets the rocket's fuel to that new amount
    /// </summary>
    private void CheckPowerBar()
    {
        gameUI.SetActive(true);
        distanceCounter = DistanceCounter.Instance;

        //If bad launch, set fuel to minimum
        if (launchPower <= .33f)
        {
            distanceCounter.MaxFuelAmount *= minimumFuelPercentage;
            distanceCounter.FuelAmount = distanceCounter.MaxFuelAmount;

            //launch distance
            distanceCounter.AddDistance(distanceFromPerfectLaunch * launchPower);
        }
        //Set fuel to 75%
        else if (launchPower <= .66f)
        {
            distanceCounter.MaxFuelAmount *= minimumFuelPercentage + .25f; 
            distanceCounter.FuelAmount = distanceCounter.MaxFuelAmount;

            //launch distance
            distanceCounter.AddDistance(distanceFromPerfectLaunch * launchPower);
        }
        //Set fuel 90%
        else if (launchPower <= .9f)
        {
            distanceCounter.MaxFuelAmount *= minimumFuelPercentage + .4f; 
            distanceCounter.FuelAmount = distanceCounter.MaxFuelAmount;

            //launch distance
            distanceCounter.AddDistance(distanceFromPerfectLaunch * launchPower);
        }
        //Set fuel to 100%
        else if (launchPower >= .9f)
        {
            distanceCounter.FuelAmount = distanceCounter.MaxFuelAmount;

            //Give player gold for a good launch
            ScoreManager.Instance.AddGold(goldFromPerfectLaunch);

            //launch distance
            distanceCounter.AddDistance(distanceFromPerfectLaunch);
        }
    }

    /// <summary>
    /// Updates the image bar to slide up and down
    /// </summary>
    void UpdateBar()
    {
        launchBar.fillAmount = launchPower;

        //Makes yellow line appear on max power for some juice
        if (launchBar.fillAmount > .9f)
        {
            maxPower.enabled = true;
        }
        else
        {
            maxPower.enabled = false;
        }
    }

}
