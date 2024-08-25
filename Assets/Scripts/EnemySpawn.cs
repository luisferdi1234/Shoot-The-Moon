using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //Variables
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float respawnTime = 1.0f;
    private Vector2 screenBounds;


    // Start is called before the first frame update
    void Start()
    {
        //Grabs screen bounds
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(enemyWave());
    }

    /// <summary>
    /// Instantiates an enemy
    /// </summary>
    private void spawnEnemy()
    {
        GameObject a = Instantiate(enemyPrefab) as GameObject;
        a.transform.position = new Vector2( Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y);
    }

    /// <summary>
    /// Spawns enemies every set amount of seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator enemyWave()
    {
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }

}
