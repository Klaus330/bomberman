using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float countdown = 2f;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(countdown > 0){
            countdown -= Time.deltaTime;
        }
        
        if(countdown < 0f)
        {
            int boost = player.GetComponent<PlayerReactions>().boost;
            FindObjectOfType<MapDestroyer>().Explode(transform.position, player, boost);
            Destroy(gameObject);
            player.GetComponent<PlayerBombSpawner>().increaseNumberOfBombs();
            countdown = 0;
            FindObjectOfType<AudioManager>().Play("explosion");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject player = other.gameObject;
        PlayerReactions abilities = player.GetComponent<PlayerReactions>();
        if(abilities == null)
        {
            return;
        }
        
        if (abilities.itCanMoveBombs()) {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }else{
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<Collider2D>().isTrigger = false;
    }
}
