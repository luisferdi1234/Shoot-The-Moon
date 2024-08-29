
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreButtonManager : MonoBehaviour
{
    /// <summary>
    /// Loads Launch Scene
    /// </summary>
    public void LaunchButton()
    {
        //loads the play scene using the function
        SceneManager.LoadScene("Scene0");
    }

    public void UpgradeButton(string upgradeName)
    {
        int currentGold = PlayerPrefs.GetInt("Gold");
        int upgradeCost = CheckPrice(upgradeName);

        if (currentGold >= upgradeCost)
        {
            //Lowers Player's Gold
            currentGold -= upgradeCost;
            PlayerPrefs.SetInt("Gold", currentGold);
            AudioManager.Instance.PlayHealthUpSound();

            //If first time upgrading then set value to 0
            if (!PlayerPrefs.HasKey(upgradeName))
            {
                PlayerPrefs.SetInt(upgradeName, 0);
            }
            else //Else increase value in player prefs by 1
            {
                //Does Player Upgrade in Player Prefs
                int newUpgrade = PlayerPrefs.GetInt(upgradeName) + 1;
                PlayerPrefs.SetInt(upgradeName, newUpgrade);
            }
        }
    }

    /// <summary>
    /// Checks the price of upgrade based on player prefs key
    /// </summary>
    /// <param name="upgradeName"></param>
    /// <returns></returns>
    int CheckPrice(string upgradeName)
    {
        if (!PlayerPrefs.HasKey(upgradeName))
        {
            //Cost is $20
            return 20;
        }
        else
        {
            if (PlayerPrefs.GetInt(upgradeName) == 0)
            {
                //Cost is $50
                return 50;
            }
            else if (PlayerPrefs.GetInt(upgradeName) == 1)
            {
                //Cost is $200
                return 200;
            }
            else if (PlayerPrefs.GetInt(upgradeName) == 2)
            {
                //Cost is $500
                return 500;
            }
        }
        return 0;
    }
}