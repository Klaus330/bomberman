using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PowerUpRandomSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Tilemap tilemapGameplay;
    public Tilemap tilemapDirt;
    public GameObject bombPrefab;

    void Start()
    {
        BoundsInt bounds = tilemapDirt.cellBounds;
        int i = 0;
        foreach (Vector3Int pos in tilemapDirt.cellBounds.allPositionsWithin)
        {

            var localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 cellCenterPosition = tilemapDirt.GetCellCenterWorld(localPlace);
            if (i == 0)
            {
                Instantiate(bombPrefab, cellCenterPosition, Quaternion.identity);
                i++;            
            }
                Debug.Log(localPlace);
        }

        //TileBase[] allTiles = tilemapDirt.GetTilesBlock(bounds);
        //Debug.Log(tilemapDirt.GetCellCenterWorld(allTiles[0]));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
