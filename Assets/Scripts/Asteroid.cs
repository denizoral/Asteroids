using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer render;
    private Rigidbody2D body;
    public float size = 1.0f;
    public float mSize = 0.5f;
    public float xSize = 1.5f;
    public float speed = 50.0f;
    public float lifetime = 50.0f;
    public AudioClip bang;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        render.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;

        body.mass = this.size;

    }

    public void setTrajectory(Vector2 direction)
    {
        body.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Missile"))
        {
           
            if ((this.size / 2.0f) >= this.mSize)
            {
                splitAsteroid();
                splitAsteroid();
            }

            FindObjectOfType<GameManager>().asteroidDestroyed(this);

            Destroy(this.gameObject);


            AudioSource.PlayClipAtPoint(bang, this.gameObject.transform.position);

        } 
    }

    private void splitAsteroid()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size / 2.0f;
        
        half.setTrajectory(Random.insideUnitCircle.normalized);
    }
}
