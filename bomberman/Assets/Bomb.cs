using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float countdown = 2f;
    public GameObject player;
    private string PLAYER_TAG = "Player";

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(PLAYER_TAG);
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown > 0){
            countdown -= Time.deltaTime;
        }
        
        if(countdown < 0f)
        {
            int boost = player.GetComponent<PlayerReactions>().boost;
            FindObjectOfType<MapDestroyer>().Explode(transform.position, boost);
            Destroy(gameObject);
            player.GetComponent<PlayerBombSpawner>().increaseNumberOfBombs();
            countdown = 0;
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
        
        if(abilities.itCanMoveBombs()){
            Debug.Log("hit");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<Collider2D>().isTrigger = false;
    }
}
