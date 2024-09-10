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
    public void LoadStoreScene()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonPress);

        StartCoroutine(LoadSceneAfterSound("UpgradeStore"));
    }

    /// <summary>
    /// Handles the Options Button Being Pressed
    /// </summary>
    public void LoadOptionsScene()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonPress);

        StartCoroutine(LoadSceneAfterSound("Options"));
    }

    /// <summary>
    /// Handles the Credits Button Being Pressed
    /// </summary>
    public void LoadCreditsScene()
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

    /// <summary>
    /// Goes to Main Menu Scene
    /// </summary>
    public void LoadMenuScene()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonPress);

        StartCoroutine(LoadSceneAfterSound("Main Menu"));
    }

    /// <summary>
    /// Waits for the button sound to finish playing before swapping to next scene
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    IEnumerator LoadSceneAfterSound(string sceneName)
    {
        //Sets time back to normal
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1f;
        }

        yield return new WaitForSeconds(buttonPress.length); // Wait for the sound to finish

        //Loads next scene
        SceneManager.LoadScene(sceneName);
    }
}
