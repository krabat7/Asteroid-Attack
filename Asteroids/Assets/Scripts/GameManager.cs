using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController _player;

    [SerializeField] ParticleSystem _explosion;

    [SerializeField] Text _coinText;

    [SerializeField] float respawnTime = 3.0f;

    [SerializeField] float respawnInvulnurbilityTime = 3.0f;

    [SerializeField] int lives = 3;

    [SerializeField] float score = 0.0f;

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this._explosion.transform.position = asteroid.transform.position;
        this._explosion.Play();

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
        this._explosion.transform.position = this._player.transform.position;
        this._explosion.Play();

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

    void Update()
    {
        _coinText.text = this.score.ToString();
    }
}
