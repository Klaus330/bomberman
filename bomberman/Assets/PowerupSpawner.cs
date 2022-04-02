using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PowerupSpawner : MonoBehaviour
{
    public List<GameObject> powerUps;
    public Tilemap tilemap;

    public void spawnPowerUp(Vector3 position)
    {
        int powerUpIndex = Random.Range(0, powerUps.Count);
        Instantiate(this.powerUps[powerUpIndex], position, Quaternion.identity);
    }
}
