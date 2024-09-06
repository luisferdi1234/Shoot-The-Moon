using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormCloudSpawner : EnemySpawn
{
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
        Vector2 spawnPosition = new Vector2(-screenBounds.x - 2, Random.Range(-screenBounds.y + 4, screenBounds.y));

        //Spawns two clouds
        GameObject a = Instantiate(enemyPrefab);
        a.transform.position = spawnPosition;

        spawnPosition.x = spawnPosition.x - 1;
        
        GameObject b = Instantiate(enemyPrefab);
        b.transform.position = spawnPosition;

    }
}
