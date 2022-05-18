using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private string PLAYER_TAG = "Player";
    private string POWERUP_TAG = "Powerup";
    private string BOMB_TAG = "Bomb";
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {
            if (other.gameObject.GetComponent<PlayerReactions>().isInvincible)
            {
                return;
            }

            other.gameObject.GetComponent<PlayerReactions>().die();
        }
        else if (other.gameObject.CompareTag(POWERUP_TAG))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag(BOMB_TAG))
        {
            int boost = player.GetComponent<PlayerReactions>().boost;
            FindObjectOfType<MapDestroyer>().Explode(other.gameObject.transform.position, player, boost);
            player.GetComponent<PlayerBombSpawner>().increaseNumberOfBombs();
            FindObjectOfType<AudioManager>().Play("explosion");
            //Destroy(other.gameObject);
        }
    }

    public void destroyObject()
    {
        Destroy(gameObject);
    }
}
