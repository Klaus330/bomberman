using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float countdown = 1f;

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        
        if(countdown <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
