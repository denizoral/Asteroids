using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ship ship;

    public ParticleSystem explode;

    public GameOver gameOver;

    public int lives = 3;

    public float respawnInvTime = 3.0f;

    public float respawnTimer = 3.0f;

    public int score = 0;
    public void asteroidDestroyed(Asteroid asteroid)
    {
        this.explode.transform.position = asteroid.transform.position;
        this.explode.Play();

        if (asteroid.size <= 0.7f) {
            score += 100;
        } else if (asteroid.size <= 1.25f) {
            score += 50;
        } else {
            score += 25;
        }
        ScoreboardManager.manager.setScore(score);
    }

    public void shipDestroyed()
    {
        this.explode.transform.position = this.ship.transform.position;
        this.explode.Play();

        this.lives--;

        ScoreboardManager.manager.setLives();

        if (this.lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), this.respawnTimer);
        }
    }

    public void Respawn()
    {
        this.ship.transform.position = Vector3.zero;
        this.ship.gameObject.layer = LayerMask.NameToLayer("RespawnCollision");
        this.ship.gameObject.SetActive(true);
        Invoke("turnOnCollision", respawnInvTime);
    }

    private void turnOnCollision()
    {
        this.ship.gameObject.layer = LayerMask.NameToLayer("Ship");
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");

        gameOver.Setup();

        //lives = 3;
       // score = 0;

        //ScoreboardManager.manager.setScore(score);
        //ScoreboardManager.manager.resetLives();

        //Invoke(nameof(Respawn), this.respawnTimer);

    }
}
