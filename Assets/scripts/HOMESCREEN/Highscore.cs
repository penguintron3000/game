using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public int scoreCount;
    public Text scoreText;

    public void Awake()
    {

        int hiscore = PlayerPrefs.GetInt("hiscore");

        try
        {
            scoreCount = PlayerPrefs.GetInt("currentHiscore");
        }
        catch (NullReferenceException)
        {
            scoreCount = 0;
        }

        setHighscore(hiscore);
    }
    public void setHighscore(int hiscore)
    {
        if(scoreCount < hiscore)
        {
            scoreCount = hiscore;
        }
        scoreText.text = "HIGH SCORE: " + scoreCount;
        PlayerPrefs.SetInt("currentHiscore", scoreCount);
        PlayerPrefs.Save();
    }
}
