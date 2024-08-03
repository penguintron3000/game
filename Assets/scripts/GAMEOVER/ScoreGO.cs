using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGO : MonoBehaviour
{
    public Text scoreCount;
    private void Awake()
    {
        int hiscore = PlayerPrefs.GetInt("hiscore");
        scoreCount.text = "" + hiscore;
    }
}
