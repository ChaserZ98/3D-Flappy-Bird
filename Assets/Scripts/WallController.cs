using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour{
	public Material leftWall;
	public Material rightWall;
	public Material ground;
	public float velocity;
    public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        velocity = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        isGameOver = GameObject.Find("Bird").GetComponent<BirdController>().isGameOver;
        if(isGameOver){
            velocity = 0;
        }
        else{
            velocity = 0.3f;
        }
        float offset = Time.time * velocity;
        leftWall.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        rightWall.SetTextureOffset("_MainTex", new Vector2(-offset, 0));
        ground.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
