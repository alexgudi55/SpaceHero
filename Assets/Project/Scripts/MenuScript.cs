using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    float highScore;
    [SerializeField]Text highScoreText;
    [SerializeField]Button right;
    [SerializeField]Button left;
    
    StrabismusData data;
    void Start()
    {
        LoadHighScore();
        data = GameObject.Find("StrabismusData").GetComponent<StrabismusData>();

    }
    /// Al llamar la el método que carga la escena, se guarda en Strabismus Data 
        // El ojo escogido.
    public void LoadScene()
    {
        if(right.interactable) data.squintEye = "right";
        else data.squintEye = "left";
        SceneManager.LoadScene("GameScene");
    }

    public void Exit()
    {
        Debug.Log("Quiting Game");
        Application.Quit();
    }
    
    public void Left()
    {
        right.interactable = false;
        left.interactable = true;
    }

    public void Right()
    {
        right.interactable = true;
        left.interactable = false;
    }

     void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High: "+ highScore;
    }
}
