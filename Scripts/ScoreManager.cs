using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;


    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    int highscore = 0;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = highscore.ToString() + " POINTS";
        
    }

    void Awake()
    {
        instance = this;
    }


    void Update()
    {
        
    }

    public void AddPoint(){

        score += 1;
        scoreText.text = score.ToString() + " POINTS";

        if(highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

}
