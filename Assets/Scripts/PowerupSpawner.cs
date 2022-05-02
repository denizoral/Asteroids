using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public static PowerupSpawner manager;

    public Powerup powerupPrefab;
   
    public float ranX;
    public float ranY;
    public Vector3 ranPos;

    public float spawnDistance = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void spawnPowerup()
    {       
         ranX = Random.Range(-10f, 10f);
         ranY = Random.Range(-5.7f, 5.7f);
         ranPos = new Vector3(ranX, ranY, 1.0f);
         Debug.Log("Chosen position" + ranPos);
         Powerup powerup = Instantiate(this.powerupPrefab, ranPos, powerupPrefab.transform.rotation);
    }
}
