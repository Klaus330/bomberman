using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBombsRandomPowerup : MonoBehaviour
{
    private string PLAYER_TAG = "Player";

     private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            FindObjectOfType<AudioManager>().Play("bonus");
            FindObjectOfType<PowerUpRandomSpawner>().emptyCell(transform.position);
            other.gameObject.GetComponent<PlayerReactions>().isPlacingBombsRandom = true;
            Destroy(gameObject);
        }
    }
}