using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Principal : MonoBehaviour{
    public bool gameStart;
    public bool gameEnd;
    public GameObject cano;
    // public int fps = 60;
    // Start is called before the first frame update
    void Start(){
        gameStart = false;
        InvokeRepeating("CreateObject", 0.0f, 5.0f);
    }

    // Update is called once per frame
    void Update(){

    }
    void GameStart(){
        gameStart = true;
    }
    void GameEnd(){
        gameEnd = true;
    }
    void CreateObject(){
        if(!gameStart){
            return;
        }
        int i = 1;
        float z = 0;
        float x = -30;
        float y = 0;
        transform.position = new Vector3(0, 0, z);
        // GameObject gameObject = new GameObject();
        switch(i){
            case 1: GameObject gameObject = Instantiate(cano); gameObject.transform.position = new Vector3(x, y, z); break;
        }
    }
}
