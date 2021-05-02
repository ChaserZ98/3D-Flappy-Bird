using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Principal : MonoBehaviour{
    public bool isGameStart;
    public bool isGameOver;
    public GameObject cano;
    // public int fps = 60;
    // Start is called before the first frame update
    void Start(){
        isGameStart = false;
        isGameOver = false;
        InvokeRepeating("CreateObject", 0.0f, 4.0f);
    }

    // Update is called once per frame
    void Update(){
        isGameStart = GameObject.Find("Bird").GetComponent<BirdController>().isGameStart;
        isGameOver = GameObject.Find("Bird").GetComponent<BirdController>().isGameOver;
    }
    void CreateObject(){
        if(!isGameStart || (isGameStart && isGameOver)){
            return;
        }
        // int num = Random.Range(1, 4);
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
    // void CreateObstacle(x){
    //     int num = Random.Range(1, 4);
    //     for(int i = 0; i < num; i++){

    //     }
    //     float y = 0;
    //     float z = Random.Range(-8, 8);
    //     GameObject obstacle = Instantiate(cano);
    //     obstacle.transform.position = new Vector3(x, y, z);
    //     return obstacle;
    // }
    // public int[] GetRandomArray(int size){
    //     Random random = new Random();
    //     int[] result = new int[size];
    //     for(int i = 0; i < size; i++){
    //         result[i]
    //     }
    // }
}
