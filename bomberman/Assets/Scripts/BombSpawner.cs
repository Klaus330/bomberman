using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile wallTile; 
    public Tile destructableTile;

    public GameObject bombPrefab;
    public Transform playerPosition;
    public float countdown = 2f;

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKey("space"))
    //    {   
    //        Vector3 position = playerPosition.position;
    //        Vector3Int cell = tilemap.WorldToCell(position);

    //        Tile placingTile = tilemap.GetTile<Tile>(cell);

    //        if(placingTile == wallTile || placingTile == destructableTile){
    //            return;
    //        }

    //        placeBomb(cell);
    //    }
    //}

    void placeBomb(Vector3Int cell)
    {
        Vector3 cellCenterPosition = tilemap.GetCellCenterWorld(cell);
        Instantiate(bombPrefab, cellCenterPosition, Quaternion.identity);
    }
}
