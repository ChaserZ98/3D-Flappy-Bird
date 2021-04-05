using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject bird;

    public GameObject main;

    public GameObject tut;

    public GameObject gaming;

    public GameObject over;

    public ZhuZiController zhuziController;

    public BgController bgController;

    public int score = 0;

    BirdController birdController;

    public bool isGameStart = false;

    public bool isTut = false;

    public Text ScoreText;

    public Text OverScoreText;

    public Text OverBestScoreText;

    public Image newImage;

    public List<Sprite> JiangPais;

    public Image JiangPai;

    private void Start()
    {
        birdController = bird.GetComponent<BirdController>();
        Screen.SetResolution(480, 854, false);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && isTut)
        {
            isTut = false;
            GameStart();
            tut.GetComponent<UIScript>().fadeOut(0.2f);
        }
    }
    public void GameStart()
    {
        isGameStart = true;
        birdController.toFly();
        zhuziController.StartSpawnZhuZi();
    }

    public void GameOver()
    {
        Debug.Log("GameOver!");
        isGameStart = false;
        DOTween.Pause("zhuzi");
        birdController.Death();
        bgController.isBegin = false;
        zhuziController.StopSpawnZhuZi();

        OverScoreText.text = score.ToString();

        if(PlayerPrefs.GetInt("BestScore") < score)
        {
            PlayerPrefs.SetInt("BestScore", score);
            newImage.color = new Color(newImage.color.r, newImage.color.g, newImage.color.b, 1);
        }

        if(score >= 40)
        {
            JiangPai.sprite = JiangPais[3];
        }
        else if(score >= 30)
        {
            JiangPai.sprite = JiangPais[2];
        }
        else if (score >= 20)
        {
            JiangPai.sprite = JiangPais[1];
        }
        else if (score >= 10)
        {
            JiangPai.sprite = JiangPais[0];
        }
        else
        {
            JiangPai.color = new Color(JiangPai.color.r, JiangPai.color.g, JiangPai.color.b, 0);
        }

        OverBestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();

        over.GetComponent<UIScript>().fadeIn(0.2f);
    }

    public void StartBtn()
    {
        main.GetComponent<UIScript>().fadeOut(0.2f);
        tut.GetComponent<UIScript>().fadeIn(0.2f);
        gaming.GetComponent<UIScript>().fadeIn(0.2f);
        isTut = true;
    }

    public void SetScore(int score)
    {
        ScoreText.text = score.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
