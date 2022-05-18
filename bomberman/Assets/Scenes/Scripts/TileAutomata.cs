using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TileAutomata : MonoBehaviour {


    [Range(0,100)]
    public int iniChance;
    [Range(1,8)]
    public int birthLimit;
    [Range(1,8)]
    public int deathLimit;

    [Range(1,10)]
    public int numR;
    private int count = 0;

    private int[,] terrainMap;
    public Vector3Int tmpSize;
    
    public Tilemap topMap;
    public Tile topTile;
    public Tile top2Tile;
    public Tile botTile;

    int width;
    int height;

    public void doSim(int nu)
    {
        clearMap(false);
        width = tmpSize.x;
        height = tmpSize.y;

        if (terrainMap==null)
            {
            terrainMap = new int[width, height];
            initPos();
            }

        terrainMap[0, 0] = terrainMap[0, 1] = terrainMap[1, 0]  = 0;
        terrainMap[width-1, 0] = terrainMap[width-1, 1] = terrainMap[width-2, 0]  = 0;
        terrainMap[0, height-1] = terrainMap[0, height-2] = terrainMap[1, height-1]  = 0;
        terrainMap[width-2, height-1] = terrainMap[width-1, height-2] = terrainMap[width-1, height-1]  = 0;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (terrainMap[x, y] == 1)
                    topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile);
                if (terrainMap[x, y] == 2)
                    topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), top2Tile);
            }
        }
    }

    public void initPos()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                terrainMap[x, y] = Random.Range(1, 3);
                if(terrainMap[x,y] == 2)
                terrainMap[x, y] = Random.Range(1, 101) > iniChance ? 0 : 2  ;
            }

        }

    }

	void Update () {

        doSim(numR);
        if (Input.GetMouseButtonDown(1))
            {
            clearMap(true);
            }   
        }
    public void clearMap(bool complete)
    {

        topMap.ClearAllTiles();
        if (complete)
        {
            terrainMap = null;
        }
    }
}