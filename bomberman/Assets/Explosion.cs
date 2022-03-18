using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float countdown = 1f;
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
            Destroy(gameObject);
            player.GetComponent<PlayerBombSpawner>().increaseNumberOfBombs();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            Debug.Log("DEAD PLAYER");
        }
    }
}
