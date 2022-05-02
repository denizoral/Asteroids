using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPref;

    public float spawnTime = 2.0f;

    public float spawnDistance = 15.0f;

    public float trajectoryVariance = 15.0f;

    public int spawnAmount = 1;
    private void Start()
    {
        InvokeRepeating(nameof(spawnAsteroids), this.spawnTime, this.spawnTime);
    }

    private void spawnAsteroids() { 
        for (int i = 0; i < this.spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;
            //spawnPoint.z = 1;
            
            
            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this.asteroidPref, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.mSize, asteroid.xSize);
            asteroid.setTrajectory(rotation * -spawnDirection);
        }
    }
}
