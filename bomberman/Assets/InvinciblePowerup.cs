using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblePowerup : MonoBehaviour
{   
    private string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            FindObjectOfType<AudioManager>().Play("bonus");
            other.gameObject.GetComponent<PlayerReactions>().isInvincible = true;
            Destroy(gameObject);
        }
    }
}
