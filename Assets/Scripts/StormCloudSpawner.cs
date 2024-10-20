using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StormCloudSpawner : EnemySpawn
{
    public GameObject[] locations;

    // Start is called before the first frame update
    protected override void Start()
    {   //set screen size//
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //Start Coroutine
        StartCoroutine(EnemyWave(SpawnCloud));
    }

    /// <summary>
    /// Instantiates two cloud objects
    /// </summary>
    private void SpawnCloud()
    {
        //Generates random spawn location
        Vector2 spawnPosition = new Vector2(-screenBounds.x + 5f , Random.Range(-screenBounds.y+5f , screenBounds.y + 1));

        //Spawns two clouds
        GameObject a = Instantiate(enemyPrefab);
        a.transform.position = spawnPosition;

        spawnPosition.x = spawnPosition.x - 1;
        spawnPosition.y = spawnPosition.y + 1;
        
        GameObject b = Instantiate(enemyPrefab);
        b.transform.position = spawnPosition;

    }
}
