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
    private void SpawnCloud()
    {
        GameObject a = Instantiate(enemyPrefab);
        a.transform.position = new Vector2(-screenBounds.x - 2, Random.Range(-screenBounds.y + 4, screenBounds.y));
    }
}
