using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReactions : MonoBehaviour
{
    public int boost = 2;
    public bool canMoveBombs = false;
    public float canMoveCountdown = 5f;
    public float hasBoostCountDown = 5f;
    public float hasMoreBombsCountDown = 5f;
    public bool hasMoreBombs = false;

    public void die()
    {
        // TO DO: dying logic
        Debug.Log("DEAD PLAYER");
        Destroy(gameObject);
    }

    public bool itCanMoveBombs()
    {
        return canMoveBombs;
    }

    void FixedUpdate()
    {
        if(canMoveBombs)
        {
            if(canMoveCountdown <= 0)
            {
                canMoveBombs = false;
                canMoveCountdown = 20f;
            }
            canMoveCountdown -= Time.fixedDeltaTime;
        }

        if(boost > 2)
        {
            if(hasBoostCountDown <= 0){
                boost = 2;
                hasBoostCountDown = 20f;
            }
            hasBoostCountDown -= Time.fixedDeltaTime;
        }

        if(hasMoreBombs)
        {
            if(hasMoreBombsCountDown <= 0){
                gameObject.GetComponent<PlayerBombSpawner>().maxNrOfBombs = 1;
                gameObject.GetComponent<PlayerBombSpawner>().numberOfBombs = 1;
                hasMoreBombs = false;
            }

            hasMoreBombsCountDown -= Time.fixedDeltaTime;
        }

    }
}
