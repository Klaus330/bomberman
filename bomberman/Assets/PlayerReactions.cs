using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReactions : MonoBehaviour
{
    public int boost = 2;

    public void die()
    {
        // TO DO: dying logic
        Debug.Log("DEAD PLAYER");
        Destroy(gameObject);
    }
}
