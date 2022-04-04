using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMoveBombsPowerUp : MonoBehaviour
{
    private string PLAYER_TAG = "Player";
    private string EXPLOSION_TAG = "Explosion";
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("HIII2IT!");
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            other.gameObject.GetComponent<PlayerReactions>().canMoveBombs = true;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag(EXPLOSION_TAG)) {
            Destroy(gameObject);
        }
    }
}