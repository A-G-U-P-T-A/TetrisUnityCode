using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static int gridHeight = 20;
    public static int gridWidth = 10;
    public static Transform[,] grid = new Transform[gridWidth,gridHeight]; 

    void Start()
    {
        SpawnNextTetramino();    
    }

    void Update()
    {
        
    }

    public void updateGrid(Tetramino tetramino)
    {
        for(int y = 0; y < gridHeight; y++)
        {
            for(int x=0; x < gridWidth; x++) 
            {
                if (grid[x, y] != null)
                {
                    if (grid[x, y].parent == tetramino.transform)
                    {
                        grid[x, y] = null;
                    }
                }
            }
        }
    }

    public bool CheckIsInsideGrid(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.y >= 0);
    }

    public Vector2 round(Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    public void SpawnNextTetramino()
    {
        GameObject nextTetramino = (GameObject)Instantiate(
            Resources.Load(getRandomTetramino(), 
            typeof(GameObject)), 
            new Vector2(5.0f, 20.0f), 
            Quaternion.identity);
    }

    string getRandomTetramino()
    {
        int randomTetromino = Random.Range(1, 8);
        
        switch (randomTetromino)
        {
            case 1:
                return "Prefabs/tetramino_J";
            case 2:
                return "Prefabs/tetramino_L";
            case 3:
                return "Prefabs/tetramino_Long";
            case 4:
                return "Prefabs/tetramino_S";
            case 5:
                return "Prefabs/tetramino_Square";
            case 6:
                return "Prefabs/tetramino_T";
            case 7:
                return "Prefabs/tetramino_Z";
            default:
                return "Prefabs/tetramino_T";
        }
    }
}
