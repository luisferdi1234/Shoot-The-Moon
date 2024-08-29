using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RespawnUI : MonoBehaviour
{
    public void LoadScene1()
    {
 
        SceneManager.LoadScene("Main Menu");
    }

        public void LoadScene2()
    {
 
        SceneManager.LoadScene("Scene0");
    }
}
