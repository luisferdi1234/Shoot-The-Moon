using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Buttons : MonoBehaviour
{
    //method to use to load Scene1
    public void LoadScene()
    {
        //loads the scene1 using the method called LoadScene
        SceneManager.LoadScene("UpgradeStore");
    }
}
