using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public int scoreCount;
    public Text scoreText;
    public GameObject board;
    // Start is called before the first frame update
    void Start()
    {
        scoreCount = 0;
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + scoreCount;
        scoreCount++;
        if(scoreCount % 1000 == 0)
        {
            Board boardObj = board.GetComponent<Board>();
            boardObj.setSpeed(boardObj.getSpeed() - .05f);
        }
    }

    public int getScore()
    {
        return scoreCount;
    }
}
