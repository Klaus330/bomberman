using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReactions : MonoBehaviour
{
    public int boost = 2;
    public bool canMoveBombs = false;
    public float canMoveCountdown = 30f;

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
                canMoveCountdown = 0f;
            }
            canMoveCountdown -= Time.fixedDeltaTime;
        }
    }
}
