using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
    public Tilemap tilemap;

    public Tile wallTile;
    public Tile destructableTile;

    public GameObject explosionPrefab;

    public int boost = 2;

    public void Explode(Vector2 worldPos)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);

        ExplodeCell(originCell);
        ExplodeInPositiveDirections(originCell);
        ExplodeInNegativeDirections(originCell);
    }

    void ExplodeInPositiveDirections(Vector3Int originCell)
    {
        ExplodeInADireciton(originCell, true, false);
        ExplodeInADireciton(originCell, false, false);
    }

    void ExplodeInNegativeDirections(Vector3Int originCell)
    {
        ExplodeInADireciton(originCell, true, true);
        ExplodeInADireciton(originCell, false, true);
    }

    void ExplodeInADireciton(Vector3Int originCell, bool isXDirection, bool isNegative)
    {
        bool cellExploded = true;
        for(int i = 1; i < boost; i++)
        {
            int value = isNegative ? i*(-1) : i;

            if(cellExploded && isXDirection)
            {
                cellExploded = ExplodeCell(originCell + new Vector3Int(value, 0, 0));
            }else if(cellExploded && !isXDirection)
            {
                cellExploded = ExplodeCell(originCell + new Vector3Int(0, value, 0));
            }
        }
    }

    bool ExplodeCell(Vector3Int cell)
    {
        Tile cellTile = tilemap.GetTile<Tile>(cell);

        if(cellTile == wallTile)
        {
            return false;
        }

        // Remove the destructable tile
        if(cellTile == destructableTile)
        {
            tilemap.SetTile(cell, null);
        }

        // Create explosion
        Vector3 position = tilemap.GetCellCenterWorld(cell);
        Instantiate(explosionPrefab, position, Quaternion.identity);

        return true;
    }
}
