using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMoreBombsPowerUp : MonoBehaviour
{
    private string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            FindObjectOfType<AudioManager>().Play("bonus");
            other.gameObject.GetComponent<PlayerBombSpawner>().maxNrOfBombs++;
            other.gameObject.GetComponent<PlayerBombSpawner>().numberOfBombs++;
            other.gameObject.GetComponent<PlayerReactions>().hasMoreBombs = true;
            Destroy(gameObject);
        }
    }
}
