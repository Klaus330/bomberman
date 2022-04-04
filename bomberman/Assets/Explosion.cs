using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private string PLAYER_TAG = "Player";
    private string POWERUP_TAG = "Powerup";
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            if(other.gameObject.GetComponent<PlayerReactions>().isInvincible)
            {
                return;
            }

            other.gameObject.GetComponent<PlayerReactions>().die();
        }else if(other.gameObject.CompareTag(POWERUP_TAG)){
            Destroy(other.gameObject);
        }
    }

    public void destroyObject()
    {
        Destroy(gameObject);
        float randomChance = Random.Range(0.0f, 1.0f);
        if(randomChance < 0.023)
        {
            FindObjectOfType<PowerupSpawner>().spawnPowerUp(transform.position);
        }
    }
}
