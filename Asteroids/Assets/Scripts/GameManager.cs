using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController _player;

    [SerializeField] ParticleSystem explosion;

    [SerializeField] float respawnTime = 3.0f;

    [SerializeField] float respawnInvulnurbilityTime = 3.0f;

    [SerializeField] int lives = 3;

    [SerializeField] float score = 0.0f;
    
    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        if (asteroid.size < 0.7f)
        {
            this.score += 100.0f;
        }
        else if (asteroid.size < 1.0f)
        {
            this.score += 75.0f;
        }
        else
        {
            this.score += 50.0f;
        }
    }

    public void PlayerDied()
    {
        this.explosion.transform.position = this._player.transform.position;
        this.explosion.Play();

        this.lives--;

        if (this.lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke("Respawn", this.respawnTime);
        }

    }

    private void GameOver()
    {
        this.lives = 3;
        this.score = 0;

        Invoke(nameof(TurnOnCollisions), this.respawnInvulnurbilityTime);
    }

    private void Respawn()
    {
        this._player.transform.position = Vector3.zero;
        this._player.gameObject.layer = LayerMask.NameToLayer("Ignore");
        this._player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), this.respawnInvulnurbilityTime);
    }

    private void TurnOnCollisions()
    {
        this._player.gameObject.layer = LayerMask.NameToLayer("Player");
    }
}
