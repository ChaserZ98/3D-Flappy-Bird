using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public GameObject startMenu;
	public GameObject scoreBoard;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
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
    	scoreBoard.GetComponent<Text>().text = score.ToString();
    	scoreBoard.SetActive(true);
        AudioManager.instance.Play("bg");
    }
    void showStartMenu(){
    	startMenu.SetActive(true);
    }
    void addPoint(){
        score++;
        scoreBoard.GetComponent<Text>().text = score.ToString();
        AudioManager.instance.Play("1point");
    }
}
