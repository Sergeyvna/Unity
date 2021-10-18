using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LoadEndScene()
    {
        SceneManager.LoadScene("End Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
