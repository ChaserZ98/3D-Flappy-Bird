using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform birdTransform;
	private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - birdTransform.position;
        transform.position = offset + birdTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + birdTransform.position;
        // Vector3 newPosition = offset + birdTransform.position;
        // transform.position = moveCamera(newPosition);
    }
    // Vector3 moveCamera(Vector3 newPosition){
    //     float newX = newPosition.x;
    //     float newY = newPosition.y;
    //     float newZ = newPosition.z;
    //     if(newPosition.y <= 2.3f){
    //         newY = 2.3f;
    //     }
    //     if(newZ <= -4.8f){
    //         newZ = -4.8f;
    //     }
    //     if(newZ >= 4.8f){
    //         newZ = 4.8f;
    //     }
    //     return new Vector3(newX, newY, newZ);
    // }
}
