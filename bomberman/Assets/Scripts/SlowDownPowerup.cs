using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownPowerup : MonoBehaviour
{
    private string PLAYER_TAG = "Player";
    public float modifiedSpeed = 1f;
    const string SLOWDOWN_TAG = "SlowDown";
    private string EXPLOSION_TAG = "Explosion";

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            FindObjectOfType<AudioManager>().Play("bonus");
            FindObjectOfType<PlayerStatusManager>().activatePowerUpForUser(other.gameObject, SLOWDOWN_TAG);
            FindObjectOfType<PowerUpRandomSpawner>().emptyCell(transform.position);
            other.gameObject.GetComponent<PlayerMovement>().isSpeedAffected = true;
             other.gameObject.GetComponent<PlayerMovement>().moveSpeed = modifiedSpeed;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag(EXPLOSION_TAG)) {
            FindObjectOfType<PowerUpRandomSpawner>().emptyCell(transform.position);
            Destroy(gameObject);
        }
    }
}
