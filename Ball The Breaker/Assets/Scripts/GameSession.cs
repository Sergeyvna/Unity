using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{
    
    public int score = 0;
    public int lives = 0;
    public int pointsPerBlock = 69;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public bool isAutoPlayEnabled;

    private SceneLoader sceneLoader;
    

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        Cursor.visible = false;
        sceneLoader = FindObjectOfType<SceneLoader>();
        scoreText.text = score.ToString();
        livesText.text = lives.ToString();
    }

    
    

    public void AddToScore()
    {
        score += pointsPerBlock;
        scoreText.text = score.ToString();
    }

    public void DecreaseLives()
    {
        lives -= 1;
        livesText.text = lives.ToString();
        if(lives == 0)
        {
            sceneLoader.LoadEndScene();
            SetHighscore();
            ResetGame();
        }
    }

    private void SetHighscore()
    {
        if(score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore",score);
        }
    }

    public void ResetGame()
    {
        gameObject.SetActive(false);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
