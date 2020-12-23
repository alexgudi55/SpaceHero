using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameUI : MonoBehaviour
{   
    [SerializeField] GameObject gameUI;
    //[SerializeField] GameObject mainMenu;
    [SerializeField] GameObject playerPrefab;

    

    void Start()
    {
        //ShowMainMenu();
        PlayGame();
        //ShowGameUI();
    }
    void OnEnable()
    {
        EventManager.onStartGame += ShowGameUI;
        EventManager.onPlayerDeath += ShowMainMenu;
    }

    void OnDisable()
    {
        EventManager.onStartGame -= ShowGameUI;
        EventManager.onPlayerDeath -= ShowMainMenu;
    }


    void ShowMainMenu()
    {
        Invoke("LoadMainMenu",6f);   
    }

    void ShowGameUI()
    {
       // mainMenu.SetActive(false);
        gameUI.SetActive(true);

        //Instantiate(playerPrefab, new Vector3(28f,25f,42f), Quaternion.identity);
    }

    public void PlayGame()
    {
        EventManager.StartGame();
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

