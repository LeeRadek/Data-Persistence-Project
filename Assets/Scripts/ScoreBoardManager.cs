using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoardManager : MonoBehaviour
{
    public TMP_Text[] scoreText = new TMP_Text[10];
    public GameObject canvas;

    void Awake()
    {
        canvas = GameObject.Find("Canvas");
        for(int i = 0; i < scoreText.Length; i++)
        {
            scoreText[i].text = DataManager.last_ScoreBoard[i].Name + " " + DataManager.last_ScoreBoard[i].score;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
