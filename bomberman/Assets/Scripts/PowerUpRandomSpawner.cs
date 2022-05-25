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
    public Tile replacementTile;
    public GameObject bombPrefab;
    public List<Vector3Int> cells;
    public List<GameObject> powerUps;
    public int listCount;
    public List<int> emptyCells;

    public IEnumerator coroutine;
    public bool buildSpirala = false;
    public float startSpirala = 16f;
    public float periodicity = 2f;

    public Vector3Int tilemapSize;

    public int height;
    public int width;

    void Start()
    {
        width = tilemapSize.x;
        height = tilemapSize.y;
        int i = 0;

        BoundsInt bounds = tilemapDirt.cellBounds;
        i = 0;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int position = new Vector3Int(-x + width / 2 , -y + height / 2, 0);
                cells.Add(position);
                emptyCells.Add(0);  
            }
        }
        listCount = cells.Count;

        tilemapDirt.SetTile(new Vector3Int(0,0,0), replacementTile);

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
        if (periodicity <= 0 && !buildSpirala)
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

    public int findCellPos(Vector3 poz)
    {
        return cells.FindIndex(cell => cell == tilemapDirt.WorldToCell(poz));
    }

    public bool isEmptyCell(Vector3 poz)
    {
        int cellPosition = cells.FindIndex(cell => cell == tilemapGameplay.WorldToCell(poz));
        return emptyCells[cellPosition] == 0;
    }

    public bool isBlockedCell(Vector3Int poz)
    {
        int cellPosition = cells.FindIndex(cell => cell == tilemapGameplay.WorldToCell(poz));
        Tile tile = tilemapGameplay.GetTile<Tile>(poz);
        
        if(tile == wallTile || tile == destructableTile || tile == spiralaWall){
            return true;
        }
        
        return emptyCells[cellPosition] == 1;
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
        int n = height;
        int m = width;
        int k = 0;
        int dr1 = n;
        int dr2 = m;
        int st = -1;
        int ok = 0;
        yield return new WaitForSecondsRealtime(startSpirala);
        buildSpirala = true;
        while (k * (n + 1) < n * n / 2)
        {

            if(!buildSpirala)
            {
                 StopCoroutine(coroutine);
            }

            int count = k;
            while (count < dr1)
            {
                st += 1;
                if(ok > 0) {
                    tilemapGameplay.SetTile(cells[st], spiralaWall);
                    FindObjectOfType<AudioManager>().Play("spawnspirala");
                    yield return new WaitForSecondsRealtime(1f);
                }
                count++;
            }
            count = k + 1;
            while (count < dr2)
            {
                st += height;
                if(ok > 0) {
                    tilemapGameplay.SetTile(cells[st], spiralaWall);
                    FindObjectOfType<AudioManager>().Play("spawnspirala");
                    yield return new WaitForSecondsRealtime(1f);
                }
                count++;
            }
            count = k + 1;
            while (count < dr1)
            {
                st -= 1;
                if(ok > 0) {
                    tilemapGameplay.SetTile(cells[st], spiralaWall);
                    FindObjectOfType<AudioManager>().Play("spawnspirala");
                    yield return new WaitForSecondsRealtime(1f);
                }
                count++;
            }
            count = k + 1;
            dr2--;
            while (count < dr2)
            {
                st -= height;
                if(ok > 0) {
                    tilemapGameplay.SetTile(cells[st], spiralaWall);
                    FindObjectOfType<AudioManager>().Play("spawnspirala");
                    yield return new WaitForSecondsRealtime(1f);
                }
                count++;
            }
            ok++;
            k++;
            dr1--;
        }
    }
}