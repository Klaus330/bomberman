using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMoreBombsPowerUp : MonoBehaviour
{
    private string PLAYER_TAG = "Player";
    const string MORE_BOMBS_TAG = "MoreBombs";
    private string EXPLOSION_TAG = "Explosion";
    
    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            FindObjectOfType<AudioManager>().Play("bonus");
            FindObjectOfType<PlayerStatusManager>().activatePowerUpForUser(other.gameObject, MORE_BOMBS_TAG);
            FindObjectOfType<PowerUpRandomSpawner>().emptyCell(transform.position);
            other.gameObject.GetComponent<PlayerBombSpawner>().maxNrOfBombs++;
            other.gameObject.GetComponent<PlayerBombSpawner>().numberOfBombs++;
            other.gameObject.GetComponent<PlayerReactions>().hasMoreBombs = true;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag(EXPLOSION_TAG)) {
            FindObjectOfType<PowerUpRandomSpawner>().emptyCell(transform.position);
            Destroy(gameObject);
        }
    }
}
