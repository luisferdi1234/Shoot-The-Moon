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

    /// <summary>
    /// Checks player prefs to see if player has bought upgrade already and updates on screen text
    /// </summary>
    void CheckUpgradeCost()
    {
        if (!PlayerPrefs.HasKey(upgradeName))
        {
            costText.text = $"Cost: $20";
        }
        else
        {
            if(PlayerPrefs.GetInt(upgradeName) == 0)
            {
                costText.text = $"Cost: $50";
            }
            else if (PlayerPrefs.GetInt(upgradeName) == 1)
            {
                costText.text = $"Cost: $200";
            }
            else if (PlayerPrefs.GetInt(upgradeName) == 2)
            {
                costText.text = $"Cost: $500";
            }
        }
    }
}
