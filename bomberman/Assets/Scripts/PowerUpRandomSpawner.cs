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
    public Tile spiralaWall;
    public Tile destructableTile;
    public GameObject bombPrefab;
    public List<Vector3Int> cells;
    public List<GameObject> powerUps;
    public int listCount;
    public List<int> emptyCells;

    public IEnumerator coroutine;
    public bool buildSpirala = true;
    public float startSpirala = 16f;
    public float periodicity = 2f;

    void Start()
    {
        BoundsInt bounds = tilemapDirt.cellBounds;
        int i = 0;
        // Debug.Log("add cells");
        foreach (Vector3Int pos in tilemapDirt.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            cells.Add(localPlace);
            emptyCells.Add(0);
        }

        listCount = cells.Count;
        // Debug.Log(listCount);
        coroutine = EndGame();
        StartCoroutine(coroutine);
    }

    public void stopSpirala()
    {
        StopCoroutine(coroutine);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (periodicity <= 0)
        {
            int index = Random.Range(0, listCount);
            if (emptyCells[index] == 1)
                return;
            Vector3Int cellPositionInt = cells[index];
            Tile cell = tilemapGameplay.GetTile<Tile>(cellPositionInt);

            if (cell != wallTile && cell != destructableTile && cell != spiralaWall)
            {
                Vector3 cellCenterPosition = tilemapDirt.GetCellCenterWorld(cellPositionInt);

                index = Random.Range(0, powerUps.Count);
                GameObject powerupPrefab = powerUps[index];

                Instantiate(powerupPrefab, cellCenterPosition, Quaternion.identity);
                emptyCells[index] = 1;
            }

            periodicity = 2f;
        }

        periodicity -= Time.fixedDeltaTime;
    }
    
    public void emptyCell(Vector3 poz)
    {
        int cellPosition = cells.FindIndex(cell => cell == tilemapDirt.WorldToCell(poz));
        emptyCells[cellPosition] = 0;
    }
    
    public void blockCell(Vector3 poz)
    {
        int cellPosition = cells.FindIndex(cell => cell == tilemapDirt.WorldToCell(poz));
        emptyCells[cellPosition] = 1;
    }

    public bool isPositionValide(Vector3 poz)
    {
        int cellPosition = cells.FindIndex(cell => cell == tilemapDirt.WorldToCell(poz));
        return emptyCells[cellPosition] == 0;
    }

    public bool isPositionValidForPlayer(Vector3 poz)
    {
        int cellPosition = cells.FindIndex(cell => cell == tilemapDirt.WorldToCell(poz));
        // Debug.Log(System.String.Format("Cell Position: {0}", cellPosition));
        Vector3Int cellCenter = cells[cellPosition];
        Tile currentCell = tilemapGameplay.GetTile<Tile>(cellCenter);
        return currentCell != spiralaWall;
    }

    IEnumerator EndGame()
    {
        int n = 16;
        int m = 14;
        int k = 0;
        int dr1 = n + 2;
        int dr2 = m + 2;
        int st = -1;
        int ok = 0;
        yield return new WaitForSecondsRealtime(startSpirala);
        while (k * (n + 1) < n * n / 2)
        {

            if(!buildSpirala)
            {
                // Debug.Log("STOP COROUTINE");
                 StopCoroutine(coroutine);
            }

            int count = k;
            while (count < dr1)
            {
                st += 1;
                if(ok>1){
                tilemapGameplay.SetTile(cells[st], spiralaWall);
                FindObjectOfType<AudioManager>().Play("spawnspirala");
                yield return new WaitForSecondsRealtime(0.2f);
                }
                count++;
            }
            count = k + 1;
            while (count < dr2)
            {
                st += 16;
                if(ok>1){
                tilemapGameplay.SetTile(cells[st], spiralaWall);
                FindObjectOfType<AudioManager>().Play("spawnspirala");
                yield return new WaitForSecondsRealtime(0.2f);
                }
                count++;
            }
            count = k + 1;
            while (count < dr1)
            {
                st -= 1;
                if(ok>1){
                tilemapGameplay.SetTile(cells[st], spiralaWall);
                FindObjectOfType<AudioManager>().Play("spawnspirala");
                yield return new WaitForSecondsRealtime(0.2f);
                }
                count++;
            }
            count = k + 1;
            dr2--;
            while (count < dr2)
            {
                st -= 16;
                if(ok>1){
                tilemapGameplay.SetTile(cells[st], spiralaWall);
                FindObjectOfType<AudioManager>().Play("spawnspirala");
                yield return new WaitForSecondsRealtime(0.2f);
                }
                count++;
            }
            ok++;
            k++;
            dr1--;
        }
    }
}