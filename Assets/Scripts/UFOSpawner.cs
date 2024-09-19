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
        a.transform.position = new Vector2( UnityEngine.Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y);
         
    }
}
