using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMoveBombsPowerUp : MonoBehaviour
{
    private string PLAYER_TAG = "Player";
    private string EXPLOSION_TAG = "Explosion";
    const string MOVE_BOMBS_TAG = "MoveBombs";

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            FindObjectOfType<PlayerStatusManager>().activatePowerUpForUser(other.gameObject, MOVE_BOMBS_TAG);
            FindObjectOfType<AudioManager>().Play("bonus");
            FindObjectOfType<PowerUpRandomSpawner>().emptyCell(transform.position);
            other.gameObject.GetComponent<PlayerReactions>().canMoveBombs = true;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag(EXPLOSION_TAG)) {
            Destroy(gameObject);
        }
    }
}
