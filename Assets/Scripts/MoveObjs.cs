using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjs : MonoBehaviour {
	public bool isGameStart = false;
	public bool isGameOver = false;
	public GameObject UI;
	// Use this for initialization
	void Start () {
		UI = GameObject.Find("Canvas");
	}
	
	// Update is called once per frame
	void Update () {
		isGameStart = GameObject.Find("Bird").GetComponent<BirdController>().isGameStart;
		if(isGameStart && !isGameOver){
			GetComponent<Rigidbody>().velocity = new Vector3(9, 0, 0);
		}
		isGameOver = GameObject.Find("Bird").GetComponent<BirdController>().isGameOver;
		if(isGameOver){
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		}
		if(transform.position.x >= 17){
			destroy();
			UI.SendMessage("addPoint");
		}
	}

    void destroy(){
        Destroy(this.gameObject);
    }
}
