using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject airplane;
    public GameObject[] locations;

    private float spawnInterval = 3f; // Time interval between spawns

    // Start is called before the first frame update
    void Start()
    {
        // Start spawning airplanes at a set interval
        InvokeRepeating("SpawnAirplane", 0f, spawnInterval);
    }

    // Method to spawn the airplane at a random location
    void SpawnAirplane()
    {
        // Check if locations array has been set
        if (locations.Length == 0) return;

        // Get a random index for the location
        int randomIndex = Random.Range(0, locations.Length);

        // Get the position of the randomly selected location
        Vector3 spawnPosition = locations[randomIndex].transform.position;

        // Instantiate the airplane at the random location
        Instantiate(airplane, spawnPosition, Quaternion.identity);
    }
}
