using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    ScoreManager scoreObj;
    public Text txt;
    private int highScore;


    // ScoreAmount
    //setCurrScore -> increases the instance's "currentScore" value by the pts received
    //                  sets the Text component of the instance with the currentScore
    public void setCurrScore(int pts)
    {
        int currentScore = Int32.Parse(txt.text);
        currentScore += pts;
        txt.text = currentScore.ToString();
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }
    //

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
