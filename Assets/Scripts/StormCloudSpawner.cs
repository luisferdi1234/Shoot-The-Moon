using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormCloudSpawner : MonoBehaviour
{

//Variables//
    [SerializeField]
    private GameObject cloudPrefab;
    [SerializeField]
    private float respawnTime = 5.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {       //set screen size//
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //call prayerpref //
        
        
            StartCoroutine(cloudWave());
        
    }
        //makes cloud spawn on the right side of the screen//
    private void spawncloud()
    {
        GameObject a = Instantiate(cloudPrefab) as GameObject;
        a.transform.position = new Vector2(-screenBounds.x - 2, Random.Range(-screenBounds.y + 4, screenBounds.y));
    }

    //set cloud spawn time//
    IEnumerator cloudWave()
    {
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawncloud();
        }
       
    }

}
