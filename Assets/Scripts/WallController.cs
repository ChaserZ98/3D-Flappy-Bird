using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour{
	public Material leftWall;
	public Material rightWall;
	public Material ground;
	public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * velocity;
        leftWall.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        rightWall.SetTextureOffset("_MainTex", new Vector2(-offset, 0));
        ground.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
