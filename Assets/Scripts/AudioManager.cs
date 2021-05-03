using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    public AudioSource bg;
    public AudioSource hit;
    public AudioSource fly;
    public AudioSource getPoint;
    public AudioSource gameOver;

    private void Awake()
    {
        if(instance == null) {
            instance = this;
        }
        else if(instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Play(string audioName) {
        switch(audioName){
            case "bg": bg.Play(); break;
            case "hit": hit.Play(); break;
            case "fly": fly.Play(); break;
            case "getPoint": getPoint.Play(); break;
            case "gameOver": gameOver.Play(); break;
        }
    }
    public void Stop(string audioName){
        switch(audioName){
            case "bg": bg.Stop(); break;
            case "hit": hit.Stop(); break;
            case "fly": fly.Stop(); break;
            case "getPoint": getPoint.Stop(); break;
            case "gameOver": gameOver.Stop(); break;
        }        
    }
}
