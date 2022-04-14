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

    public void placeBomb()
    {
        if (numberOfBombs == 0)
        {
            return;
        }

        Vector3 playerPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3Int cell = tilemap.WorldToCell(playerPosition);
        Tile placingTile = tilemap.GetTile<Tile>(cell);

        if(placingTile == wallTile || placingTile == destructableTile || !FindObjectOfType<PowerUpRandomSpawner>().isPositionValide(playerPosition)){
                return;
        }

        Vector3 cellCenterPosition = tilemap.GetCellCenterWorld(cell);
        bombPrefab.GetComponent<Bomb>().player = gameObject;
        FindObjectOfType<PowerUpRandomSpawner>().blockCell(playerPosition);
        Instantiate(bombPrefab, cellCenterPosition, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("placeBomb");
        numberOfBombs--;
    }

    public void increaseNumberOfBombs()
    {
        if(maxNrOfBombs > numberOfBombs){
            numberOfBombs++;
        }
    }
}
