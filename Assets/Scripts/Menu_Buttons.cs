using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Buttons : MonoBehaviour
{
    /// <summary>
    /// Method to use to load Scene0
    /// </summary>
    public void LoadScene()
    {
        //loads the scene1 using the method called LoadScene
        SceneManager.LoadScene("UpgradeStore");
    }

    public void LoadOptions()
    {
        //loads the scene1 using the method called LoadScene
        SceneManager.LoadScene("Options");
    }

    public void LoadCredits()
    {
 
        SceneManager.LoadScene("Credits");
    }


}
