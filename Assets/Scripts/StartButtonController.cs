using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonController : MonoBehaviour
{
	public GameObject bird;
	public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        Button startButton = this.GetComponent<Button>();
        startButton.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnClick(){
    	bird.SendMessage("GameStart", true);
    	canvas.SendMessage("HideStartMenu");
    }
}
