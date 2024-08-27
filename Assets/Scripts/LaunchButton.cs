using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchButton : MonoBehaviour
{
    //loads launch scene
    public void LoadScene(){
        //loads the play scene using the function
        SceneManager.LoadScene("Scene0");
    }
}