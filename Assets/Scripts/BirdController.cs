using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class BirdController : MonoBehaviour{
    // public Text score;
    public bool isGameOver = false;
    public bool isGameStart = false;
    // public GameObject camera;

    public float jump_speed = 5.0f;
    public GameObject bird;
    void GameStart(bool flag){
        isGameStart = flag;
        GetComponent<Rigidbody>().isKinematic = false;
    }
    void Start(){
        // Physics.gravity = new Vector3(0, -50, 0);
        isGameOver = false;
        isGameStart = false;
        GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
        GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
        transform.localPosition = new Vector3(15f, 5f, 0f);
        transform.localEulerAngles = new Vector3(0f, 90f, 0);
        Animation animation = bird.GetComponent<Animation>();
        animation.Stop();
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "obstacle"){
            isGameOver = true;
            Debug.Log(1);
            GetComponent<Rigidbody>().isKinematic = true;
        }
        else{
            Debug.Log(other.gameObject.name);
        }
    }
    void Update(){
        if(!isGameStart){
            bird.GetComponent<Animation>().Play();
        }
        else if(isGameStart && !isGameOver){
            if(Input.GetKeyDown(KeyCode.Space)){
                this.GetComponent<Rigidbody>().velocity = Vector3.up * this.jump_speed;
                bird.GetComponent<Animation>().Stop();
                bird.GetComponent<Animation>().Play();
            }
            if(Input.GetKey(KeyCode.A)){
                transform.Translate(Vector3.right * Time.deltaTime * 4);
                // if(CheckAngle(transform.localEulerAngles.z) <= 30f){
                //     transform.Rotate(new Vector3(0, 0, 30 * Time.deltaTime));
                // }
            }
            else if(Input.GetKey(KeyCode.D)){
                transform.Translate(Vector3.left * Time.deltaTime * 4);
                // if(CheckAngle(transform.localEulerAngles.z) >= -30f){
                //     transform.Rotate(new Vector3(0, 0, -30 * Time.deltaTime));
                // }
            }
            else{
                // if(CheckAngle(transform.localEulerAngles.z) < 0){
                //     transform.Rotate(new Vector3(0, 0, 30 * Time.deltaTime));
                // }
                // else if(CheckAngle(transform.localEulerAngles.z) > 0){
                //     transform.Rotate(new Vector3(0, 0, -30 * Time.deltaTime));
                // }
            }
        }
    }
    public float CheckAngle(float value){
        float angle = value - 180;
        if(angle > 0){
            return angle - 180;
        }
        if(value == 0){
            return 0;
        }
        return angle + 180;
    }
}