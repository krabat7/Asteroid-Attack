using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController _player;

    [SerializeField] float respawnTime = 3.0f;

    [SerializeField] float respawnInvulnurbilityTime = 3.0f;

    [SerializeField] int lives = 3;

    public void PlayerDied()
    {
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
        //ToDo
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
