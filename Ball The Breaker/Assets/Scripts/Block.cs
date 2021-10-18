using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    public AudioClip blockCrackSound;
    public GameObject blockParticles;
    public Sprite[] hitSprites;
    public int hits;

    private Level level;

    private void Start()
    {
        CountBrBlocks();
    }

    private void CountBrBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();  
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            BlockBreakingCheck();
        }
    }

    private void BlockBreakingCheck()
    {
        hits++;
        int maxHits = hitSprites.Length + 1;
        if (hits >= maxHits) 
        { 
            DestroyBlock();
        } 
        else 
        {
            ShowNextHitSprite();
            BlockDestroySFX();
            TriggerParticleVFX();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = hits - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        BlockDestroySFX();
        TriggerParticleVFX();
        Destroy(gameObject);
        level.BlockDestroyed();
    }

    
    private void BlockDestroySFX()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(blockCrackSound, transform.position);
    }

    private void TriggerParticleVFX()
    {
       GameObject sparkles = Instantiate(blockParticles, transform.position, blockParticles.transform.rotation); 
       Destroy(sparkles,1f);
    }
}
