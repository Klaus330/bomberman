using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private string PLAYER_TAG = "Player";
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            other.gameObject.GetComponent<PlayerReactions>().die();
        }
    }

    public void destroyObject()
    {
        // Debug.Log("Booom");
        Destroy(gameObject);
        float randomChance = Random.Range(0.0f, 1.0f);
        Debug.Log("Random change");
        Debug.Log(randomChance);
        if(randomChance < 0.018)
        {
            FindObjectOfType<PowerupSpawner>().spawnPowerUp(transform.position);
        }
    }
}
