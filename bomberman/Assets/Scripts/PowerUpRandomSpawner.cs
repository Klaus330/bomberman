using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PowerUpRandomSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Tilemap tilemapGameplay;
    public Tilemap tilemapDirt;
    public Tile wallTile;
    public Tile destructableTile;
    public GameObject bombPrefab;
    public List<Vector3Int> cells;
    public List<GameObject> powerUps;
    public int listCount;

    public float periodicity = 2f;

    void Start()
    {
        BoundsInt bounds = tilemapDirt.cellBounds;
        int i = 0;
        Debug.Log("add cells");
        foreach (Vector3Int pos in tilemapDirt.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            cells.Add(localPlace);
        }

        listCount = cells.Count;
        Debug.Log(listCount);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(periodicity <= 0)
        {
            int index = Random.Range(0, listCount);
            Vector3Int cellPositionInt = cells[index];
            Tile cell = tilemapGameplay.GetTile<Tile>(cellPositionInt);

            if(cell != wallTile && cell != destructableTile)
            {
                Vector3 cellCenterPosition = tilemapDirt.GetCellCenterWorld(cellPositionInt);

                index = Random.Range(0, powerUps.Count);
                GameObject powerupPrefab = powerUps[index];

                Instantiate(powerupPrefab, cellCenterPosition, Quaternion.identity);
            }

            periodicity = 2f;
        }

        periodicity -= Time.fixedDeltaTime;
    }
}
