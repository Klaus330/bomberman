using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject bombPrefab;
    public Transform playerPosition;
    public float countdown = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            Vector3Int cell = tilemap.WorldToCell(playerPosition.position);
            Vector3 cellCenterPosition = tilemap.GetCellCenterWorld(cell);

            Instantiate(bombPrefab, cellCenterPosition, Quaternion.identity);
        }
    }
}
