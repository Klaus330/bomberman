using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallerExplosionPowerUp : MonoBehaviour
{
    private string PLAYER_TAG = "Player";
    private string EXPLOSION_TAG = "Explosion";
    // const string LESS_EFFECT_TAG = "LessEffect";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            FindObjectOfType<AudioManager>().Play("bonus");
            // FindObjectOfType<PlayerStatusManager>().activatePowerUpForUser(other.gameObject, LESS_EFFECT_TAG);
            FindObjectOfType<PowerUpRandomSpawner>().emptyCell(transform.position);
            if (other.gameObject.GetComponent<PlayerReactions>().boost > 2)
            {
                other.gameObject.GetComponent<PlayerReactions>().boost--;
            }
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag(EXPLOSION_TAG)) {
            FindObjectOfType<PowerUpRandomSpawner>().emptyCell(transform.position);
            Destroy(gameObject);
        }
    }
}
