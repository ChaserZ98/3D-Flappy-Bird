using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public GameObject startMenu;
	public GameObject scoreBoard;
    public GameObject gameOverMenu;
    public GameObject finalScore;
    public GameObject bestScoreTextGameStart;
    public GameObject newBest;
    public int score;
    public int bestScore;
    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreTextGameStart.GetComponent<Text>().text = bestScore.ToString();
        // Debug.Log(bestScore);
        score = 0;
    	startMenu.SetActive(true);
    	// scoreBoard = GameObject.Find("Canvas/Score");
    	scoreBoard.SetActive(false);
        newBest.SetActive(false);
        gameOverMenu.SetActive(false);
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
    void showGameOverMenu(){
        finalScore.GetComponent<Text>().text = score.ToString();
        scoreBoard.SetActive(false);
        gameOverMenu.SetActive(true);
        AudioManager.instance.Play("gameOver");
        if(score > bestScore){
            PlayerPrefs.SetInt("BestScore", score);
            newBest.SetActive(true);
        }
    }
    void addPoint(){
        score++;
        scoreBoard.GetComponent<Text>().text = score.ToString();
        AudioManager.instance.Play("getPoint");
    }
}
