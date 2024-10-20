using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class CloudSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] locations;
    public GameObject[] clouds;

    [SerializeField]public float spawnInterval = 4f; // Time interval between spawns

    // Start is called before the first frame update
    void Start()
    {
        // Start spawning airplanes at a set interval
        InvokeRepeating("spawnclouds", 0f, spawnInterval);
    }

    // Method to spawn the airplane at a random location
    void spawnclouds()
    {
        // Check if locations array has been set
        if (locations.Length == 0) return;

        int cloudss = Random.Range(0, clouds.Length);
        // Get a random index for the location
        int randomIndex = Random.Range(0, locations.Length);

        // Get the position of the randomly selected location
        Vector3 spawnPosition = locations[randomIndex].transform.position;

        // Instantiate the airplane at the random location
        Instantiate(clouds[cloudss], spawnPosition, Quaternion.identity);
    }
}
