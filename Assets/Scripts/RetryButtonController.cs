using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetryButtonController : MonoBehaviour
{
	public GameObject bird;
	public GameObject canvas;
	public GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {
        Button retryButton = this.GetComponent<Button>();
        retryButton.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnClick(){
    	bird.SendMessage("Start");
    	canvas.SendMessage("Start");
    	obstacle.SendMessage("Start");
    }
}
