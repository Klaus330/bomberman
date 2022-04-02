using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReactions : MonoBehaviour
{
    public int boost = 2;
    public bool canMoveBombs = false;
    public float canMoveCountdown = 5f;
    public float hasBoostCountDown = 5f;

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
    }
}
