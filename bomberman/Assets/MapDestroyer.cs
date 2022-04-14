using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
    public Tilemap tilemap;

    public Tile wallTile;
    public Tile spirala;
    public Tile destructableTile;
    public GameObject explosionPrefab;
    public float spawnPowerUpChance = 0.6f;
    public GameObject player;

    public void Explode(Vector2 worldPos, GameObject p, int boost = 1)
    {
        player = p;
        FindObjectOfType<PowerUpRandomSpawner>().emptyCell(new Vector3(worldPos.x,worldPos.y,0));
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
        for(int i = 1; i < boost && cellExploded; i++)
        {
            int value = isNegative ? i*(-1) : i;
            Vector3Int offset = isXDirection ? new Vector3Int(value, 0, 0) : new Vector3Int(0, value, 0);
    
            Vector3Int nextCellPosition = originCell + offset;
            Tile nextCell = tilemap.GetTile<Tile>(nextCellPosition);
            cellExploded = ExplodeCell(nextCellPosition);
            // Debug.Log(nextCell);
            if(nextCell == destructableTile)
            {
                float randomChance = Random.Range(0.0f, 1.0f);
                if (randomChance < spawnPowerUpChance)
                {
                    StartCoroutine(spawnarPower(nextCellPosition));
                }
                // Debug.Log(System.String.Format("HIT A DESTRUCTABLE. In xdirection:{0}, isNegative:{1}, iteration: {2}", isXDirection, isNegative, i));
                cellExploded = false;
            }
            
        }
    }
    IEnumerator spawnarPower(Vector3Int cell)
    {
        Vector3 cellCenterPosition = tilemap.GetCellCenterWorld(cell);
        yield return new WaitForSecondsRealtime(0.8f);
        FindObjectOfType<PowerupSpawner>().spawnPowerUp(cellCenterPosition);
    }

     bool ExplodeCell(Vector3Int cell)
    {
        Tile cellTile = tilemap.GetTile<Tile>(cell);

        if(cellTile == wallTile || cellTile == spirala)
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
        explosionPrefab.GetComponent<Explosion>().player = player;
        Instantiate(explosionPrefab, position, Quaternion.identity);

        return true;
    }
}
