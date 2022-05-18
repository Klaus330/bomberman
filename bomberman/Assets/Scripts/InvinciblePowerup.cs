using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblePowerup : MonoBehaviour
{   
    const string INVINCIBLE_TAG = "Invincible";
    private string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            FindObjectOfType<PlayerStatusManager>().activatePowerUpForUser(other.gameObject, INVINCIBLE_TAG);
            FindObjectOfType<AudioManager>().Play("bonus");
            FindObjectOfType<PowerUpRandomSpawner>().emptyCell(transform.position);
            other.gameObject.GetComponent<PlayerReactions>().isInvincible = true;
            Destroy(gameObject);
        }
    }
}
