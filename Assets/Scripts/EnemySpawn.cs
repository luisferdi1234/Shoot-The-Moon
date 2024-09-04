using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //Variables
    [SerializeField]
    protected GameObject enemyPrefab;
    [SerializeField]
    protected float respawnTime = 1.0f;
    protected Vector2 screenBounds;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        //Grabs screen bounds
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(EnemyWave(SpawnEnemy));
    }

    /// <summary>
    /// Instantiates an enemy
    /// </summary>
    private void SpawnEnemy()
    {
        GameObject a = Instantiate(enemyPrefab);
        a.transform.position = new Vector2( UnityEngine.Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y);
    }

    /// <summary>
    /// Spawns enemies every set amount of seconds
    /// </summary>
    /// <returns></returns>
    protected IEnumerator EnemyWave(Action methodToCall)
    {
        while(true){
            yield return new WaitForSeconds(respawnTime);
            methodToCall();
        }
    }

}
