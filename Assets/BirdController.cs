using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour{
    public float jump_speed = 5.0f;
    public GameObject bird;
    void Start(){
        Animation animation = bird.GetComponent<Animation>();
        animation.Stop();
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            this.GetComponent<Rigidbody>().velocity = Vector3.up * this.jump_speed;
            bird.GetComponent<Animation>().Stop();
            bird.GetComponent<Animation>().Play();
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Translate(Vector3.left * Time.deltaTime * 2);
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right * Time.deltaTime * 2);
        }
    }
}