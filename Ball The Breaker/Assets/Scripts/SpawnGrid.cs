using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrid : MonoBehaviour
{
    public GameObject[] blocks;
    public int gridX;
    public int gridY;
    public float blockOffsetX = 1f;
    public float blockOffsetY = 1f;
    public Vector2 gridPos = Vector2.zero;

    private void Start()
    {
        SpawnBlocks();
    }

    public void SpawnBlocks()
    {
        for(int x = 0; x < gridX; x++)
        {
            for(int y = 0; y < gridY; y++)
            {
                Vector2 spawnPos = new Vector2(x * blockOffsetX, y * blockOffsetY) + gridPos;
                PickRandomBlock(spawnPos);
            }
        }
    }

    private void PickRandomBlock(Vector2 spawnPos)
    {
        int randomIndex = Random.Range(0,blocks.Length);
        GameObject block = Instantiate(blocks[randomIndex],spawnPos,Quaternion.identity);
    }
}
