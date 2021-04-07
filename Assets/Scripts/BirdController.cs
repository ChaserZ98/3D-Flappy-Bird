using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class BirdController : MonoBehaviour{
    // public Text score;
    private bool isGameOver = false;
    // public GameObject camera;

    public float jump_speed = 5.0f;
    public GameObject bird;
    void Start(){
        // Physics.gravity = new Vector3(0, -50, 0);
        GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
        GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
        transform.localPosition = new Vector3(15f, 5f, 0f);
        transform.localEulerAngles = new Vector3(0f, 90f, 0);
        Animation animation = bird.GetComponent<Animation>();
        animation.Stop();
    }
    // void FixedUpdate(){
    //     if(this.isGameOver){
    //         return;
    //     }
    //     if(this.GetComponent<Rigidbody>().velocity.y > 0){
    //         this.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(0, 180, -20f));
    //     }
    //     else{
    //         this.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(0, 180, 20f));
    //     }

    //     if(Input.GetKeyDown("space")){
    //         // if(this.score.text == "Flappy Bird"){
    //         //     this.score.text = "0";
    //         //     this.GetComponent<Rigidbody>().isKinematic = false;
    //         // }
    //         this.GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
    //         this.GetComponent<Rigidbody>().AddForce(Vector3.up * 50f, ForceMode.Impulse);
    //     }
    // }
    void Update(){
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