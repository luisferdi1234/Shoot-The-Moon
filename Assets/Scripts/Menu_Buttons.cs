using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Buttons : MonoBehaviour
{
    [SerializeField]
    AudioClip buttonPress;

    /// <summary>
    /// Method to use to load Scene0
    /// </summary>
    public void LoadScene()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonPress);
        //loads the scene1 using the method called LoadScene
        SceneManager.LoadScene("UpgradeStore");
    }

    public void LoadOptions()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonPress);
        //loads the Options Scene
        SceneManager.LoadScene("Options");
    }

    public void LoadCredits()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonPress);

        //Loads the Credits Scene
        SceneManager.LoadScene("Credits");
    }


}
