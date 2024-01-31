using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public Transform spawnPoints;
    public Spaceship spaceship;
    public float startTime = 3;
    public GameObject prefabAsteroid;
    public float spawnInterval = 2;

    private Vector2[] asteroidSpawnPositions;
    private float spawnCooldown;

    void Start()
    {
        int i = 0;
        foreach (Transform child in spawnPoints)
        {
            //numbers.Add(child.position);
            i += 1;
        }
        asteroidSpawnPositions = new Vector2[i];
        //
        i = 0;
        foreach (Transform child in spawnPoints)
        {
            asteroidSpawnPositions[i] = child.position;
            i += 1;
        }
    }


    void SpawnAsteroid()
    {
        int rngIndex = Random.Range(0, asteroidSpawnPositions.Length-1);
        GameObject instanceAsteroid = Instantiate(prefabAsteroid, asteroidSpawnPositions[rngIndex], spaceship.transform.rotation);
        instanceAsteroid.GetComponent<Asteroid>().InitiateAsteroid(spaceship.transform.position);
    }

    void FixedUpdate()
    {
        startTime -= Time.deltaTime;
        if (startTime <= 0.0f)
        {
            spawnCooldown -= Time.deltaTime;
            if (spawnCooldown < 0f)
            {
                SpawnAsteroid();
                spawnCooldown = spawnInterval;
            }
            
        }
    }
}
