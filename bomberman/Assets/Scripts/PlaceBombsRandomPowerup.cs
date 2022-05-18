using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBombsRandomPowerup : MonoBehaviour
{
    private string PLAYER_TAG = "Player";
    const string RANDOM_BOMBS_TAG = "RandomBombs";

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            FindObjectOfType<AudioManager>().Play("bonus");
            FindObjectOfType<PlayerStatusManager>().activatePowerUpForUser(other.gameObject, RANDOM_BOMBS_TAG);
            FindObjectOfType<PowerUpRandomSpawner>().emptyCell(transform.position);
            other.gameObject.GetComponent<PlayerReactions>().isPlacingBombsRandom = true;
            Destroy(gameObject);
        }
    }
}
