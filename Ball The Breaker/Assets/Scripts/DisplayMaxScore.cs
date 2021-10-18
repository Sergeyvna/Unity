using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMaxScore : MonoBehaviour
{
    public TextMeshProUGUI maxScoreText;
    
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.visible = true;
        maxScoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore");
    }
}
