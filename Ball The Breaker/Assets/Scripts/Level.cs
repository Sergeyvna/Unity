using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    public int breakableBlocks;
    public GameObject block;
    
    private SpawnGrid spawnGrid;
    private Ball ball;

    private void Start()
    {
        spawnGrid = FindObjectOfType<SpawnGrid>();
        ball = FindObjectOfType<Ball>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            ball.ResetBall();
            spawnGrid.SpawnBlocks();
        }
    }
  
}
