using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static GameLogic Instance;

    Vector3 offset;

    public float droptime = 0.9f;

    public float quickDropTime = 0.05f;

    public static int width = 15, height = 30;

    public GameObject[] Block;

    public Transform[,] grid = new Transform[width, height];

    private Vector2 NextBlock = new Vector2(18.5f, 26.5f);


    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        offset = new Vector3(7.5f, 28.5f);

        if (GameManager.Instance.isGameActive == true)
        {
            SpawnBlock();
        }

        
    }

    void Update()
    {
        
        
    }


    public void ClearLines()
    {
        for (int y = 0; y < height; y++)
        {
            if (isLineComplete(y))
            {
                DestroyLineFull(y);

                MoveAllLines(y);

                ScoreManager.Instance.score += 3; // change score

                ScoreManager.Instance.UpdateScore();

                ScoreManager.Instance.LevelUpdate();

                ScoreManager.Instance.BestScore();

                
            }
        }
    }

    public void MoveLines(int y)
    {
        for (int x = 0; x < width; ++x)
        {
            if (grid[x, y] != null)
            {
                grid[x, y - 1] = grid[x, y];

                grid[x, y] = null;

                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }

    }

    public void MoveAllLines(int y)
    {
        for(int i = y; i < height; i++)
        {
            MoveLines(i);
        }
    }

    void DestroyLineFull(int y)
    {
        for (int x = 0; x < width; x++)
        {
            Destroy(grid[x, y].gameObject);

            grid[x, y] = null;
        }
    }

    

    bool isLineComplete(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if(grid[x,y] == null)
            {
                return false;
            }
        }
        return true;
    }


    public void SpawnBlock()
    {
        float guess = Random.Range(0, 1f);
        guess *= Block.Length;
        Instantiate(Block[Mathf.FloorToInt(guess)], offset, Block[Mathf.FloorToInt(guess)].transform.rotation);
    }
}
