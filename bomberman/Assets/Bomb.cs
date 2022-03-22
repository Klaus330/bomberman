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
        countdown -= Time.deltaTime;
        
        if(countdown <= 0f)
        {
            int boost = player.GetComponent<PlayerReactions>().boost;
            FindObjectOfType<MapDestroyer>().Explode(transform.position, boost);
            Destroy(gameObject);
            player.GetComponent<PlayerBombSpawner>().increaseNumberOfBombs();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
           GetComponent<Collider2D>().isTrigger = false;
    }
}
