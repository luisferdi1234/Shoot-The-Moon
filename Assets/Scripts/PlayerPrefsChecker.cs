using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsChecker : MonoBehaviour
{
    [SerializeField]
    private GameObject GameUI;

    [SerializeField]
    private GameObject LaunchUI;

    [SerializeField]
    private GameObject Rocket;

    private void Awake()
    {
        CheckFuel();
        CheckLaunch();
        CheckSpeed();
        CheckWeapons();
        CheckDefense();
    }

    /// <summary>
    /// Increases Max Fuel Amount
    /// </summary>
    void CheckFuel()
    {
        if (PlayerPrefs.HasKey("Fuel"))
        {
            if (PlayerPrefs.GetInt("Fuel") == 0)
            {
                GameUI.GetComponent<DistanceCounter>().MaxFuelAmount = 30f;
            }
            else if (PlayerPrefs.GetInt("Fuel") == 1)
            {
                GameUI.GetComponent<DistanceCounter>().MaxFuelAmount = 60f;
            }
            else if (PlayerPrefs.GetInt("Fuel") == 2)
            {
                GameUI.GetComponent<DistanceCounter>().MaxFuelAmount = 120f;
            }
        }

        GameUI.SetActive(false);
    }

    /// <summary>
    /// Increases Max Fuel Amount
    /// </summary>
    void CheckSpeed()
    {
        if (PlayerPrefs.HasKey("Speed"))
        {
            if (PlayerPrefs.GetInt("Speed") == 0)
            {
                Rocket.GetComponent<Rocket>().MoveSpeed = 3;
            }
            else if (PlayerPrefs.GetInt("Speed") == 1)
            {
                Rocket.GetComponent<Rocket>().MoveSpeed = 4;
            }
            else if (PlayerPrefs.GetInt("Speed") == 2)
            {
                Rocket.GetComponent<Rocket>().MoveSpeed = 5;
            }
        }
    }

    /// <summary>
    /// Lowers the cooldown in between player shots
    /// </summary>
    void CheckWeapons()
    {
        if (PlayerPrefs.HasKey("Weapon"))
        {
            if (PlayerPrefs.GetInt("Weapon") == 0)
            {
                Rocket.GetComponent<Rocket>().MaxShotCooldown = .5f;
            }
            else if (PlayerPrefs.GetInt("Weapon") == 1)
            {
                Rocket.GetComponent<Rocket>().MaxShotCooldown = .25f;
            }
            else if (PlayerPrefs.GetInt("Weapon") == 2)
            {
                Rocket.GetComponent<Rocket>().MaxShotCooldown = 0;
            }
        }
    }

    /// <summary>
    /// Lowers the amount of fuel lost from a hit from enemy
    /// </summary>
    void CheckDefense()
    {
        if (PlayerPrefs.HasKey("Defense"))
        {
            if (PlayerPrefs.GetInt("Defense") == 0)
            {
                Rocket.GetComponent<Rocket>().FuelLossFromHit = .5f;
            }
            else if (PlayerPrefs.GetInt("Defense") == 1)
            {
                Rocket.GetComponent<Rocket>().FuelLossFromHit = .25f;
            }
            else if (PlayerPrefs.GetInt("Defense") == 2)
            {
                Rocket.GetComponent<Rocket>().FuelLossFromHit = .1f;
            }
        }
    }

    /// <summary>
    /// Increases Gold Gained from perfect launch and Distance Gained
    /// </summary>
    void CheckLaunch()
    {
        if (PlayerPrefs.HasKey("Launch"))
        {
            if (PlayerPrefs.GetInt("Launch") == 0)
            {
                LaunchUI.GetComponent<LaunchScript>().GoldFromPerfectLaunch = 40;
                LaunchUI.GetComponent<LaunchScript>().DistanceFromPerfectLaunch = 20f;
            }
            else if (PlayerPrefs.GetInt("Launch") == 1)
            {
                LaunchUI.GetComponent<LaunchScript>().GoldFromPerfectLaunch = 50;
                LaunchUI.GetComponent<LaunchScript>().DistanceFromPerfectLaunch = 30f;
            }
            else if (PlayerPrefs.GetInt("Launch") == 2)
            {
                LaunchUI.GetComponent<LaunchScript>().GoldFromPerfectLaunch = 60;
                LaunchUI.GetComponent<LaunchScript>().DistanceFromPerfectLaunch = 40f;
            }
        }
    }
}
