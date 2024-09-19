using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : EnemySpawn
{
   // Start is called before the first frame update
    protected override void Start()
    {   //set screen size//
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //Start Coroutine
        StartCoroutine(EnemyWave(SpawnUFO));

    }

 
    private void SpawnUFO()
    {
        GameObject a = Instantiate(enemyPrefab);

        int spawnSide = Random.Range(0, 1);

        if (spawnSide == 0)
        {
            a.transform.position = new Vector2(-screenBounds.x, Random.Range(0, screenBounds.y + 4));
        }
        else
        {
            a.transform.position = new Vector2(screenBounds.x, Random.Range(0, screenBounds.y + 4));
        }
    }
}
