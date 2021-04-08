using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public GameObject startMenu;
	public GameObject scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
    	startMenu.SetActive(true);
    	scoreBoard = GameObject.Find("Canvas/Score");
    	scoreBoard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void HideStartMenu(){
    	//Game start
    	startMenu.SetActive(false);
    	scoreBoard.GetComponent<Text>().text = "0";
    	scoreBoard.SetActive(true);
    }
    void showStartMenu(){
    	startMenu.SetActive(true);
    }
}
