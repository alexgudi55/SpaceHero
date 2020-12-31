using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] public float timePassed;
    [SerializeField] public Text timerText;
    bool keepTime = false;

    void Start()
    {
        //timerText = GameObject.Find("Timer").GetComponent<Text>();
    }

    void Update()
    {
        if(keepTime) 
        { 
            timePassed += Time.deltaTime;  
            UpdateTimerDisplay();
        }
    }
    void OnEnable()
    {
        EventManager.onStartGame += StartTimer;
        EventManager.onPlayerDeath += StopTimer;
    }

    void OnDisable()
    {
        EventManager.onStartGame -= StartTimer;
        EventManager.onPlayerDeath -= StopTimer;
    }
    

    void StartTimer()
    {
        timePassed = 0;
        keepTime = true;
    }

    void StopTimer()
    {
        keepTime = false;
    }

    void UpdateTimerDisplay()
    {
        int minutes;
        float seconds;

        minutes = Mathf.FloorToInt(timePassed / 60);
        seconds = timePassed % 60;

        timerText.text = string.Format("{0}:{1:00.00}", minutes, seconds);
        if(minutes == 2)
        {
            EventManager.PlayerDeath();
        }
    }
}
