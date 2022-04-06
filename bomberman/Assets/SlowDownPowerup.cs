using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownPowerup : MonoBehaviour
{
    private string PLAYER_TAG = "Player";
    public float modifiedSpeed = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            FindObjectOfType<AudioManager>().Play("bonus");
            other.gameObject.GetComponent<PlayerMovement>().isSpeedAffected = true;
             other.gameObject.GetComponent<PlayerMovement>().moveSpeed = modifiedSpeed;
            Destroy(gameObject);
        }
    }
}
