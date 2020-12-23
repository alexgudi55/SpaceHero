using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
   // [SerializeField] AudioSource mainMenuMusic;
    [SerializeField] AudioSource gameBackgroundSound;
    

    void OnEnable()
    {
        EventManager.onStartGame += PlayBackgroundMusic;
        //EventManager.onPlayerDeath += PlayMenuMusic;
    }
    void OnDisable()
    {
        EventManager.onStartGame -= PlayBackgroundMusic;
        //EventManager.onPlayerDeath -= PlayMenuMusic;
    }

    /*void PlayMenuMusic()
    {
        gameBackgroundSound.Stop();
        mainMenuMusic.Play();
    }*/

    void PlayBackgroundMusic()
    {
        //mainMenuMusic.Stop();
        gameBackgroundSound.PlayDelayed(2f);
    }
}
