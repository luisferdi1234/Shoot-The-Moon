using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBalloonSpawner : EnemySpawn
{
    // Start is called before the first frame update
    protected override void Start()
    {   //set screen size//
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //Start Coroutine
        StartCoroutine(EnemyWave(SpawnBalloon));

    }

    /// <summary>
    /// Spawns Balloons in the left or right side of the screen and near the top
    /// </summary>
    private void SpawnBalloon()
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
