using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Variables
    [SerializeField]
    TextMeshProUGUI descriptionText;
    [SerializeField]
    TextMeshProUGUI costText;
    [SerializeField]
    TextMeshProUGUI goldText;

    [SerializeField] 
    string upgradeDescription;
    [SerializeField]
    string upgradeName;

    // This method is called when the mouse enters the button area.
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (descriptionText != null)
        {
            descriptionText.text = upgradeDescription;
            CheckUpgradeCost();
        }
    }

    // This method is called when the mouse exits the button area.
    public void OnPointerExit(PointerEventData eventData)
    {
        if (descriptionText != null)
        {
            descriptionText.text = ""; // Clear the description.
            costText.text = "";
        }
    }

    public void RefreshText()
    {
        //Refreshes Current Hovered Over Cost
        if (!PlayerPrefs.HasKey(upgradeName))
        {
            costText.text = $"Cost: $25";
        }
        else
        {
            if (PlayerPrefs.GetInt(upgradeName) == 0)
            {
                costText.text = $"Cost: $75";
            }
            else if (PlayerPrefs.GetInt(upgradeName) == 1)
            {
                costText.text = $"Cost: $225";
            }
            else if (PlayerPrefs.GetInt(upgradeName) == 2)
            {
                costText.text = $"Cost: $675";
            }
        }

        //Refreshes Player Gold
        int gold = PlayerPrefs.GetInt("Gold");
        goldText.text = $"Gold: ${gold}";
    }

    /// <summary>
    /// Checks player prefs to see if player has bought upgrade already and updates on screen text
    /// </summary>
    void CheckUpgradeCost()
    {
        if (!PlayerPrefs.HasKey(upgradeName))
        {
            costText.text = $"Cost: $25";
        }
        else
        {
            if(PlayerPrefs.GetInt(upgradeName) == 0)
            {
                costText.text = $"Cost: $75";
            }
            else if (PlayerPrefs.GetInt(upgradeName) == 1)
            {
                costText.text = $"Cost: $225";
            }
            else if (PlayerPrefs.GetInt(upgradeName) == 2)
            {
                costText.text = $"Cost: $675";
            }
        }
    }
}
