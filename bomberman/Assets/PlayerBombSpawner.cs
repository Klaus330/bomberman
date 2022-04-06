using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerBombSpawner : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile wallTile; 
    public Tile destructableTile;
    public GameObject bombPrefab;
    public int maxNrOfBombs = 1;
    public int numberOfBombs = 1;
    public PlayerReactions playerReactions;


    void Start()
    {
        tilemap = GameObject.FindGameObjectWithTag("Playground").GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {   
            placeBombAtCurrentPosition();
        }
    }

    public void placeBombAtCurrentPosition()
    {
        if(numberOfBombs == 0)
        {
            return;
        }

        int x = Mathf.FloorToInt(gameObject.transform.position.x);
        int y = Mathf.FloorToInt(gameObject.transform.position.y);
        int z = Mathf.FloorToInt(gameObject.transform.position.z);
        Vector3 playerPosition = new Vector3(x, y, z);
        Vector3Int cell = tilemap.WorldToCell(playerPosition);
        Tile placingTile = tilemap.GetTile<Tile>(cell);

        if(placingTile == wallTile || placingTile == destructableTile){
            return;
        }

        placeBomb(cell);
        numberOfBombs--;
    }

    void placeBomb(Vector3Int cell)
    {
        Vector3 cellCenterPosition = tilemap.GetCellCenterWorld(cell);

        Instantiate(bombPrefab, cellCenterPosition, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("placeBomb");
    }

    public void increaseNumberOfBombs()
    {
        if(maxNrOfBombs > numberOfBombs){
            numberOfBombs++;
        }
    }
}
