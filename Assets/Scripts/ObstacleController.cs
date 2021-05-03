using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleController : MonoBehaviour{
    public bool isGameStart;
    public bool isGameOver;
    public GameObject ObstacleContainer;
    public GameObject upObstacle;
    public GameObject downObstacle;
    public float generationPositionX;

    // public int fps = 60;
    // Start is called before the first frame update
    void Start(){
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("obstacleContainer");
        foreach(GameObject obstacle in obstacles){
            Destroy(obstacle);
        }
        generationPositionX = -30f;
        isGameStart = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update(){
        if(!isGameStart && GameObject.Find("Bird").GetComponent<BirdController>().isGameStart){
            isGameStart = GameObject.Find("Bird").GetComponent<BirdController>().isGameStart;
            CreateObstacle();
            generationPositionX = -60f;
            InvokeRepeating("CreateObject", 0.0f, 3.5f);
        }
        else{
            isGameStart = GameObject.Find("Bird").GetComponent<BirdController>().isGameStart;
        }
        if(!isGameOver && GameObject.Find("Bird").GetComponent<BirdController>().isGameOver){
            isGameOver = GameObject.Find("Bird").GetComponent<BirdController>().isGameOver;
            CancelInvoke("CreateObject");
        }
        else{
            isGameOver = GameObject.Find("Bird").GetComponent<BirdController>().isGameOver;
        }
    }
    void CreateObject(){
        if(!isGameStart || (isGameStart && isGameOver)){
            return;
        }
        CreateObstacle();
    }
    void CreateObstacle(){
        //Type 1: Linear
        //Type 2: partial all close
        //Type 3: Circle
        int obstacleType = Random.Range(1, 4);
        // int obstacleType = 3;
        switch(obstacleType){
            case 1: CreateLinearObstacle(generationPositionX); break;
            case 2: CreatePartialObstacle(generationPositionX); break;
            case 3: CreateCircleObstacle(generationPositionX); break;
        }
    }
    void CreateLinearObstacle(float x){
        GameObject obstacleContainer = Instantiate(ObstacleContainer);
        obstacleContainer.transform.position = new Vector3(x, 0, 0);
        int obstacleNum = Random.Range(6, 10);
        float emptyScale = Random.Range(4.0f, 6.0f);
        float center_y = Random.Range(0.5f * emptyScale, 15.0f - 0.5f * emptyScale);
        float up_scale = 15.0f - (center_y + 0.5f * emptyScale);
        float down_scale = center_y - 0.5f * emptyScale;
        // Debug.Log("obstacleNum " + obstacleNum);
        int[] randomZArray = GetRandomArray(-8, 8, obstacleNum, 2);
        for(int i = 0; i < obstacleNum; i++){
            GameObject up = Instantiate(upObstacle, obstacleContainer.transform);
            up.transform.localScale = new Vector3(1, 1, up_scale);
            up.transform.position = new Vector3(x, 15, randomZArray[i]);
            GameObject down = Instantiate(downObstacle, obstacleContainer.transform);
            down.transform.localScale = new Vector3(1, 1, down_scale);
            down.transform.position = new Vector3(x, 0, randomZArray[i]);
        }
    }
    void CreatePartialObstacle(float x){
        GameObject obstacleContainer = Instantiate(ObstacleContainer);
        obstacleContainer.transform.position = new Vector3(x, 0, 0);
        int obstacleNum = Random.Range(4, 7);
        int startZ = -8 + 2 * Random.Range(0, 9 - obstacleNum + 1);
        int[] zArray = new int[obstacleNum];
        for(int i = 0; i < obstacleNum; i++){
            zArray[i] = startZ + 2 * i;
        }
        for(int i = 0; i < obstacleNum; i++){
            GameObject down = Instantiate(downObstacle, obstacleContainer.transform);
            down.transform.localScale = new Vector3(1, 1, 15);
            down.transform.position = new Vector3(x, 0, zArray[i]);
        }
    }
    void CreateCircleObstacle(float x){
        GameObject obstacleContainer = Instantiate(ObstacleContainer);
        obstacleContainer.transform.position = new Vector3(x, 0, 0);
        int emptyScale = Random.Range(3, 10);
        int centerUpObstacleScale = Random.Range(0, 15 - emptyScale);
        int centerDownObstacleScale = 15 - emptyScale - centerUpObstacleScale;
        // int centerObstacleScale = Random.Range(3, 6);
        GameObject centerUp = Instantiate(upObstacle, obstacleContainer.transform);
        centerUp.transform.localScale = new Vector3(1, 1, centerUpObstacleScale);
        centerUp.transform.position = new Vector3(x, 15, 0);
        GameObject centerDown = Instantiate(downObstacle, obstacleContainer.transform);
        centerDown.transform.localScale = new Vector3(1, 1, centerDownObstacleScale);
        centerDown.transform.position = new Vector3(x, 0, 0);
        for(int i = 1; i < 5; i++){
            int positionZ = 2 * i;
            float upScale;
            float downScale;
            float empty = emptyScale - 2 * i;
            if(empty >= 0){
                upScale = centerUpObstacleScale + i;
                downScale = centerDownObstacleScale + i;
            }
            else{
                upScale = centerUpObstacleScale + 0.5f * emptyScale;
                downScale = centerDownObstacleScale + 0.5f * emptyScale;
            }

            GameObject rightUp = Instantiate(upObstacle, obstacleContainer.transform);
            rightUp.transform.localScale = new Vector3(1, 1, upScale);
            rightUp.transform.position = new Vector3(x, 15, positionZ);
            GameObject rightDown = Instantiate(downObstacle, obstacleContainer.transform);
            rightDown.transform.localScale = new Vector3(1, 1, downScale);
            rightDown.transform.position = new Vector3(x, 0, positionZ);

            GameObject leftUp = Instantiate(upObstacle, obstacleContainer.transform);
            leftUp.transform.localScale = new Vector3(1, 1, upScale);
            leftUp.transform.position = new Vector3(x, 15, -positionZ);
            GameObject leftDown = Instantiate(downObstacle, obstacleContainer.transform);
            leftDown.transform.localScale = new Vector3(1, 1, downScale);
            leftDown.transform.position = new Vector3(x, 0, -positionZ);
        }
    }
    public int[] GetRandomArray(int minValue, int maxValue, int count, int interval = 1){
        System.Random rnd = new System.Random();
        int length = (maxValue - minValue) / interval + 1;
        byte[] keys = new byte[length];
        rnd.NextBytes(keys);
        int[] items = new int[length];
        for (int i = 0; i < length; i++){
            items[i] = interval * i + minValue;
        }
        System.Array.Sort(keys, items);
        int[] result = new int[count];
        System.Array.Copy(items, result, count);
        return result;
    }
}
