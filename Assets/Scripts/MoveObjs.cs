using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjs : MonoBehaviour {
	// public bool gameStart = false;
	// Use this for initialization
	void Start () {
		// if(gameStart){
			GetComponent<Rigidbody>().velocity = new Vector3(3f, 0, 0);
			Invoke("destroi", 16);
		// }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void destroi()
    {
        Destroy(this.gameObject);
    }
}
