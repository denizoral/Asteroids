using UnityEngine;

public class Missile : MonoBehaviour
{
    private Rigidbody2D body;

    public float missileSpeed = 500.0f;

    public float missileTimeout = 10.0f;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void CreateMissile(Vector2 direction)
    {
        body.AddForce(direction * this.missileSpeed);

        Destroy(this.gameObject, this.missileTimeout); //destroy after 10 seconds (time can be adjusted in the editor)
    }
}
