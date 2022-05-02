using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    //private SpriteRenderer render;
    //private Rigidbody2D powerup;
    public float lifetime = 5.0f;


    private void Awake()
    {
        //render = GetComponent<SpriteRenderer>();
        //powerup = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Once spawned the powerups will destroy after 5 seconds
        Destroy(this.gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            FindObjectOfType<GameManager>().pickUpPowerup();

            Destroy(gameObject);
        }
    }
}
