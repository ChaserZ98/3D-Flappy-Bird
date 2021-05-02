using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjs : MonoBehaviour {
	public bool isGameOver = false;
	// Use this for initialization
	void Start () {
		// if(gameStart){
			GetComponent<Rigidbody>().velocity = new Vector3(9, 0, 0);
			// Invoke("destroi", 16);
		// }
	}
	
	// Update is called once per frame
	void Update () {
		isGameOver = GameObject.Find("Bird").GetComponent<BirdController>().isGameOver;
		if(isGameOver){
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		}
		if(transform.position.x >= 17){
			destroy();
		}
	}

    void destroy()
    {
        Destroy(this.gameObject);
    }
}
