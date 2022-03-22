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

    public void Explode(Vector2 worldPos, int boost = 1)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);

        ExplodeCell(originCell);
        ExplodeInPositiveDirections(originCell, boost);
        ExplodeInNegativeDirections(originCell, boost);
    }

    void ExplodeInPositiveDirections(Vector3Int originCell, int boost)
    {
        ExplodeInADireciton(originCell, boost, true, false);
        ExplodeInADireciton(originCell, boost, false, false);
    }

    void ExplodeInNegativeDirections(Vector3Int originCell, int boost)
    {
        ExplodeInADireciton(originCell, boost, true, true);
        ExplodeInADireciton(originCell, boost, false, true);
    }

    void ExplodeInADireciton(Vector3Int originCell, int boost, bool isXDirection, bool isNegative)
    {
        bool cellExploded = true;
        for(int i = 1; i < boost; i++)
        {
            int value = isNegative ? i*(-1) : i;

            if(cellExploded && isXDirection)
            {
                Vector3Int nextCellPosition = originCell + new Vector3Int(value, 0, 0);
                Tile nextCell = tilemap.GetTile<Tile>(nextCellPosition);
                cellExploded = ExplodeCell(nextCellPosition);
                if(nextCell == destructableTile)
                {
                    cellExploded = false;
                }
            }else if(cellExploded && !isXDirection)
            {
                Vector3Int nextCellPosition = originCell + new Vector3Int(0, value, 0);
                Tile nextCell = tilemap.GetTile<Tile>(nextCellPosition);
                cellExploded = ExplodeCell(nextCellPosition);
                if(nextCell == destructableTile)
                {
                    cellExploded = false;
                }
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
