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
    [SerializeField]Canvas main;
    [SerializeField]Canvas instructions;
    
    
    
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

    public void ShowInstructions()
    {   
        main.enabled = false;
        instructions.enabled = true;
        GameObject.Find("Pickup").transform.position = new Vector3(-12.8f,14.4f,69.3f);
        GameObject.Find("Enemy").transform.position = new  Vector3(16.3f,3.4f,49.6f);
    }

    public void ShowMainMenu()
    {
        main.enabled = true;
        instructions.enabled = false;
        GameObject.Find("Pickup").transform.position = new Vector3(-1112.8f,14.4f,69.3f);
        GameObject.Find("Enemy").transform.position = new  Vector3(-1116.3f,3.4f,49.6f);
    }

    

     void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High: "+ highScore;
    }
}
