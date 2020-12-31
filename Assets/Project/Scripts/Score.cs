using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{   
    [SerializeField]Text highSc;
    ///[SerializeField]Text highScMain;
    
    [SerializeField]Text curScore;

    Timer time;
    int score;
    int highScore;

    void Start()
    {
        //highSc = GameObject.Find("HighScore").GetComponent<Text>();
        //curScore = GameObject.Find("Score").GetComponent<Text>();

        LoadHighScore();
        //DisplayScoreMainMenu();
        time = GameObject.Find("CanvasR").GetComponent<Timer>();
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

        string puntaje = score.ToString();
        string tiempo = time.timerText.text;

        ConsultasSQL sql = new ConsultasSQL(); 
        CameraSettingsBD camera = GameObject.Find("LeftCamera").GetComponent<CameraSettingsBD>();
        string paciente = camera.idPaciente;
        string especialista = camera.idEspecialista;
        sql.insertTratamiento("Oclución de objetos",puntaje,tiempo,paciente,especialista);
        Debug.Log(puntaje + " <--- Score LOL");
        Debug.Log(tiempo + " <---- Time LOL");
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
