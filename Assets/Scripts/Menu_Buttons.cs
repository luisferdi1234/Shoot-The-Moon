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

        StartCoroutine(LoadSceneAfterSound("UpgradeStore"));
    }

    /// <summary>
    /// Handles the Options Button Being Pressed
    /// </summary>
    public void LoadOptions()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonPress);

        StartCoroutine(LoadSceneAfterSound("Options"));
    }

    /// <summary>
    /// Handles the Credits Button Being Pressed
    /// </summary>
    public void LoadCredits()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonPress);

        StartCoroutine(LoadSceneAfterSound("Credits"));
    }

    /// <summary>
    /// Handles the Quit Button Being Pressed
    /// </summary>
    public void ExitButton()
    {
        Application.Quit();
    }

    IEnumerator LoadSceneAfterSound(string sceneName)
    {
        yield return new WaitForSeconds(buttonPress.length); // Wait for the sound to finish
        SceneManager.LoadScene(sceneName);
    }
}
