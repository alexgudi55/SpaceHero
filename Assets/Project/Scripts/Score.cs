using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{   
    [SerializeField]Text highSc;
    ///[SerializeField]Text highScMain;
    
    [SerializeField]Text curScore;
    int score;
    int highScore;

    void Start()
    {
        //highSc = GameObject.Find("HighScore").GetComponent<Text>();
        //curScore = GameObject.Find("Score").GetComponent<Text>();

        LoadHighScore();
        //DisplayScoreMainMenu();
    }


    void OnEnable()
    {
        EventManager.onStartGame += ResetScore;
        EventManager.onPlayerDeath += CheckNewHighScore;
        EventManager.onScorePoints += AddScore;
    }
    void OnDisable()
    {
        EventManager.onStartGame -= ResetScore;
        EventManager.onPlayerDeath -= CheckNewHighScore;
        EventManager.onScorePoints -= AddScore;
    }
    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void ResetScore()
    {
        score = 0;
        DisplayScore();
    }
    void CheckNewHighScore()
    {
        if(score >= highScore)  
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = score; 
        }
        DisplayScore();
        //DisplayScoreMainMenu();
    }

    void AddScore(int amt)
    {
        score += amt;
        DisplayScore();
    }

    void DisplayScore()
    {
        highSc.text = "High: " + highScore.ToString();
        curScore.text = "Score: "+score.ToString();
    }

    void DisplayScoreMainMenu()
    {
       // highScMain.text = "High: " + highScore.ToString();
    }

    
}
