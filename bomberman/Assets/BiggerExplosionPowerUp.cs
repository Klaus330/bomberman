using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerExplosionPowerUp : MonoBehaviour
{
    private string PLAYER_TAG = "Player";
    private string EXPLOSION_TAG = "Explosion";
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            other.gameObject.GetComponent<PlayerReactions>().boost++;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag(EXPLOSION_TAG)) {
            Destroy(gameObject);
        }
    }
}